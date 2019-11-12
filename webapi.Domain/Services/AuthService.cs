using System;
using System.Security.Cryptography;
using System.Text;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IRepository<Evaluator> _evaluatorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(
            IAuthRepository authRepository,
            IRepository<Evaluator> evaluatorRepository,
            IUnitOfWork unitOfWork)
        {
            this._authRepository = authRepository;
            this._evaluatorRepository = evaluatorRepository;
            this._unitOfWork = unitOfWork;
        }
        
        public bool authenticate(Auth credentials)
        {
            if (!string.IsNullOrEmpty(credentials.Email) && !string.IsNullOrEmpty(credentials.Password))
            {
                Auth obj = this._authRepository.authenticate(credentials);
                var salt = obj.SaltPassword;
                var password = this.createHash(credentials.Password, salt);

                if (password == obj.HashPassword){
                    return true;
                }
            }
            return false;
        }

        public object register(Auth credentials)
        {
            this._unitOfWork.BeginTransaction();

            this.newGuid(credentials);

            if (credentials.Evaluator != null)
                this._evaluatorRepository.insert(credentials.Evaluator);

            string salt = this.createSalt(10);
            string hash = this.createHash(credentials.Password, salt);

            credentials.SaltPassword = salt;
            credentials.HashPassword = hash;
            credentials.Password = null;

            var obj = this._authRepository.insert(credentials);

            this._unitOfWork.Commit();

            return obj;
        }

        public string createSalt(int size){
            byte[] salt = new byte[size];
            using (var rgb = RNGCryptoServiceProvider.Create())
            {
                rgb.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public string createHash(string password, string salt){
            
            byte[] hash;

            string passwordSalted = password + salt;

            using (var hmac = new SHA256CryptoServiceProvider())
            {
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordSalted));
            }

            return Convert.ToBase64String(hash);
        }

        private void newGuid(Auth credentials)
        {
            if (credentials.Evaluator != null)
                credentials.Evaluator.Id = Guid.NewGuid();
            
            credentials.Id = Guid.NewGuid();
        }
    }
}