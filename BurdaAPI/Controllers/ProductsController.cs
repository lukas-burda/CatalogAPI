using CatalogAPI.Interfaces;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        readonly IProductsRepository _repository;
        public ProductsController(IProductsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var products = _repository.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }



        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {

                var product = _repository.GetById(id);

                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            try
            {
                var product = _repository.Create(model);
                return Created($"api/products/{product.Id}", product);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { ex.Message, ex.ParamName });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(Guid id, [FromBody] Product model)
        {
            try
            {
                _repository.Update(id, model);

                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { ex.Message, ex.ParamName });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _repository.Delete(id);

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
