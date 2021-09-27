using CatalogAPI.Interfaces;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkusController : ControllerBase
    {
        readonly ISkusRepository _repository;
        public SkusController(ISkusRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var skus = _repository.GetAll();
                return Ok(skus);
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
                var sku = _repository.GetById(id);

                if (sku == null)
                    return NotFound();

                return Ok(sku);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sku model)
        {
            try
            {
                var sku = _repository.Create(model);
                return Created($"api/skus/{sku.Id}", sku);
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

        [HttpPatch("{id}")]
        public IActionResult Patch(Guid id, [FromBody] Sku model)
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
    }
}
