using System;
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
            var obj = this._authRepository.authenticate(credentials);
            return obj;
        }

        public object register(Auth credentials)
        {
            this._unitOfWork.BeginTransaction();

            this.newGuid(credentials);

            if (credentials.Evaluator != null)
                this._evaluatorRepository.insert(credentials.Evaluator);

            var obj = this._authRepository.insert(credentials);

            this._unitOfWork.Commit();

            return obj;
        }

        private void newGuid(Auth credentials)
        {
            if (credentials.Evaluator != null)
                credentials.Evaluator.Id = Guid.NewGuid();
            
            credentials.Id = Guid.NewGuid();
        }
    }
}