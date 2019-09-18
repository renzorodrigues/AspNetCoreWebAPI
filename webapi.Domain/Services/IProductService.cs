using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IProductService
    {
         IEnumerable<Product> getAll();
         Product getById(int id);
    }
}