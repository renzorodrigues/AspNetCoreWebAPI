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

        private readonly IUnitOfWork _unitOfWork;

        public AttendedService(
            IRepository<Attended> repository,
            IRepository<Contact> repositoryContact,
            IRepository<Tutor> repositoryTutor,
            IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._repositoryContact = repositoryContact;
            this._repositoryTutor = repositoryTutor;
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

        public void insert(Attended Attended)
        {
            this._unitOfWork.BeginTransaction();

            this.newGuid(Attended);
           
            if (Attended.Contact != null)
                this._repositoryContact.insert(Attended.Contact);
            
            if (Attended.Tutor != null)
                this._repositoryTutor.insert(Attended.Tutor);
            
            this._repository.insert(Attended);

            this._unitOfWork.Commit();
        }

        public void update(Guid id, Attended attended)
        {
            this._unitOfWork.BeginTransaction();

            Attended entity = this._repository.getById(id);

            updateData(entity, attended);

            this._unitOfWork.Commit();
        }

        public void delete(Guid id)
        {
            this._unitOfWork.BeginTransaction();

            Attended entity = this._repository.getById(id);

            this._repository.delete(entity);

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
                entity.Contact.TelphoneNumber = attended.Contact.TelphoneNumber;
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

        private void newGuid(Attended attended)
        {
            if (attended.Contact != null)
                attended.Contact.Id = Guid.NewGuid();

            if (attended.Tutor != null)
                attended.Tutor.Id = Guid.NewGuid();
                
            attended.Id = Guid.NewGuid();
        }
    }
}