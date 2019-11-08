using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IRepository<Evaluator> _evaluatorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateGUID _createGuid;
        private readonly ApplicationSettings _appSettings;

        public UserAuthService(
            IUserAuthRepository userAuthRepository,
            IRepository<Evaluator> evaluatorRepository,
            ICreateGUID createGUID,
            IOptions<ApplicationSettings> appSettings,
            IUnitOfWork unitOfWork)
        {
            this._userAuthRepository = userAuthRepository;
            this._evaluatorRepository = evaluatorRepository;
            this._createGuid = createGUID;
            this._appSettings = appSettings.Value;
            this._unitOfWork = unitOfWork;
        }
        public string authenticate(UserAuth credentials)
        {
            var obj = this._userAuthRepository.authenticate(credentials);

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

        public UserAuth register(UserAuth credentials)
        {
            if (credentials != null)
            {
                this._unitOfWork.BeginTransaction();

                this.GenerateSalt(credentials);

                this._createGuid.newGuid(credentials.Id);
                this._userAuthRepository.insert(credentials);

                this._unitOfWork.Commit();
            }

            return credentials;
        }

        private void GenerateSalt(UserAuth credentials) {
            using (var hmacsha256 = new HMACSHA256())
            {
                byte[] salt;

                using (RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider())
                {
                    salt = new byte[32];
                    saltGenerator.GetBytes(salt);
                }

                credentials.SaltPassword = Convert.ToBase64String(salt);
            }
        }
    }
}