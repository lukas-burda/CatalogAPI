using CatalogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Interfaces
{
    public interface ISkusRepository
    {
        IEnumerable<Sku> GetAll();
        Sku GetById(Guid id);
        Sku Create(Sku model);
        void Update(Guid id, Sku model);
        void Delete(Guid id);

    }
}
