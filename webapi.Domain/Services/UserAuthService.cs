using System;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserAuthRepository _authRepository;
        private readonly IRepository<Evaluator> _evaluatorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateGUID _createGuid;

        public AuthService(
            IUserAuthRepository authRepository,
            IRepository<Evaluator> evaluatorRepository,
            ICreateGUID createGUID,
            IUnitOfWork unitOfWork)
        {
            this._authRepository = authRepository;
            this._evaluatorRepository = evaluatorRepository;
            this._createGuid = createGUID;
            this._unitOfWork = unitOfWork;
        }
        public bool authenticate(UserAuth credentials)
        {
            var obj = this._authRepository.authenticate(credentials);
            return obj;
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