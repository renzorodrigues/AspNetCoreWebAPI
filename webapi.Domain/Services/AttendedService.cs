using System;
using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class AttendedService : IAttendedService
    {
        private readonly IRepository<Attended> _repository;
        private readonly IRepository<Contact> _repositoryContact;
        private readonly IRepository<Tutor> _repositoryTutor;
        private readonly IAttendedRepository _attendedRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateGUID _createGuid;

        public AttendedService(
            IRepository<Attended> repository,
            IRepository<Contact> repositoryContact,
            IRepository<Tutor> repositoryTutor,
            IAttendedRepository attendedRepository,
            ICreateGUID createGUID,
            IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._repositoryContact = repositoryContact;
            this._repositoryTutor = repositoryTutor;
            this._attendedRepository = attendedRepository;
            this._createGuid = createGUID;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Attended> getAll()
        {
            return this._repository.getAll().ToList();
        }

        public Attended getById(Guid id)
        {
            return this._repository.getById(id);
        }

        public object insert(Attended attended)
        {
            this._unitOfWork.BeginTransaction();
           
            if (attended.Contact != null)
            {
                this._createGuid.newGuid(attended.Contact.Id);
                this._repositoryContact.insert(attended.Contact);
            }

            if (attended.Tutor != null)
            {
                this._createGuid.newGuid(attended.Tutor.Id);
                this._repositoryTutor.insert(attended.Tutor);
            }
            
            this._createGuid.newGuid(attended.Id);
            var obj =  this._repository.insert(attended);
            this._unitOfWork.Commit();
            return obj;
        }

        public void delete(Guid id)
        {
            this._unitOfWork.BeginTransaction();

            Attended entity = this._repository.getById(id);

            this._repository.delete(entity);

            this._unitOfWork.Commit();
        }

        public void update(Guid id, Attended attended)
        {
            this._unitOfWork.BeginTransaction();

            Attended entity = this._repository.getById(id);

            updateData(entity, attended);

            this._unitOfWork.Commit();
        }

        private void updateData(Attended entity, Attended attended)
        {
            entity.Name = attended.Name;
            entity.RegistrationNumber = attended.RegistrationNumber;
            entity.Gender = attended.Gender;
            entity.BirthDate = attended.BirthDate;
            entity.RegistrationDate = attended.RegistrationDate;
            
            if (entity.Contact != null)
            {
                entity.Contact.TelephoneNumber = attended.Contact.TelephoneNumber;
                entity.Contact.MobileNumber = attended.Contact.MobileNumber;
                entity.Contact.Email = attended.Contact.Email;
            }
            else
            {
                if (attended.Contact != null)
                {
                    attended.Contact.Id = Guid.NewGuid();
                    this._repositoryContact.insert(attended.Contact);
                    entity.Contact = attended.Contact;
                }
            }

            if (entity.Tutor != null)
            {
                entity.Tutor.Name = attended.Tutor.Name;
                entity.Tutor.TutorType = attended.Tutor.TutorType;
            }
            else
            {
                if (attended.Tutor != null)
                {
                    attended.Tutor.Id = Guid.NewGuid();
                    this._repositoryTutor.insert(attended.Tutor);
                    entity.Tutor = attended.Tutor;
                }      
            }
        }
        public IEnumerable<Attended> getByName(string search)
        {
            return this._attendedRepository.getByName(search);
        }
    }
}