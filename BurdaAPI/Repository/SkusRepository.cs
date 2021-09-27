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
    public class SkusRepository : ISkusRepository
    {
        private Context _context = new Context();
        readonly IProductsRepository _productsRepository;

        public SkusRepository(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IEnumerable<Sku> GetAll()
        {
            return _context.Sku.ToList();
        }

        public Sku GetById(Guid id)
        {
            return _context.Sku.FirstOrDefault(x => x.Id == id);
        }

        public Sku Create(Sku model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new ArgumentNullException(nameof(Sku.Name), "O nome do produto é obrigatório.");
            if (string.IsNullOrEmpty(model.ImageUrl))
                throw new ArgumentNullException(nameof(Sku.ImageUrl), "A imagem do produto é obrigatória.");
            if (string.IsNullOrEmpty(model.Barcode))
                throw new ArgumentNullException(nameof(Sku.Barcode), "O código de barras é obrigatório.");
            if (string.IsNullOrEmpty(model.Price.ToString()))
                throw new ArgumentNullException(nameof(Sku.Price), "O preço é obrigatório.");
            if (model.ProductId == Guid.Empty)
                throw new ArgumentNullException(nameof(Sku.ProductId), "O id do produto é obrigatório.");

            var product = _productsRepository.GetById(model.ProductId);

            if (product == null)
                throw new InvalidOperationException("Produto não encontrado");

            model.Id = Guid.NewGuid();

            _context.Add(model);
            _context.SaveChanges();

            return model;
        }

        public void Update(Guid id, Sku model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new ArgumentNullException(nameof(Sku.Name), "O nome do produto é obrigatório.");
            if (string.IsNullOrEmpty(model.ImageUrl))
                throw new ArgumentNullException(nameof(Sku.ImageUrl), "A imagem do produto é obrigatória.");
            if (string.IsNullOrEmpty(model.Barcode))
                throw new ArgumentNullException(nameof(Sku.Barcode), "O código de barras é obrigatório.");
            if (string.IsNullOrEmpty(model.Price.ToString()))
                throw new ArgumentNullException(nameof(Sku.Price), "O preço é obrigatório.");
            if (model.ProductId == Guid.Empty)
                throw new ArgumentNullException(nameof(Sku.ProductId), "O id do produto é obrigatório.");

            var sku = GetById(id);

            if (sku == null)
                throw new InvalidOperationException("Sku não encontrado.");

            var product = _productsRepository.GetById(model.ProductId);

            if (product == null)
                throw new InvalidOperationException("Produto não encontrado");

            sku.ImageUrl = model.ImageUrl;
            sku.Name = model.Name;
            sku.Price = model.Price;
            sku.Barcode = model.Barcode;

            _context.Update(sku);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                throw new ArgumentNullException(nameof(Sku.Id), "O id do Sku é obrigatório");

            var sku = GetById(id);

            if (sku == null)
                throw new InvalidOperationException("Sku não encontrado.");

            _context.Remove(sku);
            _context.SaveChanges();
        }
    }
}
