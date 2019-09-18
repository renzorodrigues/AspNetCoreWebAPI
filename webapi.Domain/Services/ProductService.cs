using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Entities;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository){
            this._repository = repository;
        }
        public IEnumerable<Product> getAll()
        {
            return this._repository.getAll().ToList();
        }

        public Product getById(int id)
        {
            return _repository.getById(id);
        }
    }
}