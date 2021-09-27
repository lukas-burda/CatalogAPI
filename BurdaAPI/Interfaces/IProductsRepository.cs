using CatalogAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Interfaces
{
    public interface IProductsRepository
    {
        Product GetById(Guid id);
        IEnumerable<Product> GetAll();
        Product Create(Product model);
        void Update(Guid id, Product model);
        void Delete(Guid id);
    }
}
