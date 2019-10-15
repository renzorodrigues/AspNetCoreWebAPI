using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUserAuthRepository _authRepository;
        private readonly IRepository<Evaluator> _evaluatorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateGUID _createGuid;
        private readonly ApplicationSettings _appSettings;

        public UserAuthService(
            IUserAuthRepository authRepository,
            IRepository<Evaluator> evaluatorRepository,
            ICreateGUID createGUID,
            IOptions<ApplicationSettings> appSettings,
            IUnitOfWork unitOfWork)
        {
            this._authRepository = authRepository;
            this._evaluatorRepository = evaluatorRepository;
            this._createGuid = createGUID;
            this._appSettings = appSettings.Value;
            this._unitOfWork = unitOfWork;
        }
        public string authenticate(UserAuth credentials)
        {
            var obj = this._authRepository.authenticate(credentials);

            if (obj != null)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", obj.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return token;
            }
            else
            {
                throw new InvalidCredentialException("Email is not registered or password is incorrect");
            }
        }

        public object register(UserAuth credentials)
        {
            this._unitOfWork.BeginTransaction();

            if (credentials.Evaluator != null)
            {
                this._createGuid.newGuid(credentials.Evaluator.Id);
                this._evaluatorRepository.insert(credentials.Evaluator);
            }

            this._createGuid.newGuid(credentials.Id);
            var obj = this._authRepository.insert(credentials);
            this._unitOfWork.Commit();
            return obj;
        }
    }
}