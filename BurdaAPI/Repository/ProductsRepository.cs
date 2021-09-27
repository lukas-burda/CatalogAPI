using CatalogAPI.Data;
using CatalogAPI.Interfaces;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Repository
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ProductsRepository : IProductsRepository
    {
        private Context _context = new Context();
        public Product Create(Product model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new ArgumentNullException(nameof(Product.Name), "O nome do produto é obrigatório.");
            if (string.IsNullOrEmpty(model.Code))
                throw new ArgumentNullException(nameof(Product.Code), "O código do produto é obrigatório.");

            model.Id = new Guid();

            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public void Delete(Guid id)
        {
            var product = GetById(id);

            if (product == null)
                throw new InvalidOperationException("Produto não encontrado");

            _context.Remove(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Product.ToList();
     
        }

        public Product GetById(Guid id)
        {
            return _context.Product.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Guid id, Product model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new ArgumentNullException(nameof(Product.Name), "O nome do produto é obrigatório.");
            if (string.IsNullOrEmpty(model.Code))
                throw new ArgumentNullException(nameof(Product.Code), "O código do produto é obrigatório.");

            var product = GetById(id);

            if (product == null)
                throw new InvalidOperationException("Produto não encontrado");

            product.Name = model.Name;
            product.Code = model.Code;

            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
