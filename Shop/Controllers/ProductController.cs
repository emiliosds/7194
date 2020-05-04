using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices]DataContext context)
        {
            var products = await context
                .Products
                .Include(o => o.Category)
                .AsNoTracking()
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById(
            int id,
            [FromServices]DataContext context)
        {
            var product = await context
                .Products
                .Include(o => o.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);

            return Ok(product);
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory(
            int id,
            [FromServices]DataContext context)
        {
            var products = await context
                .Products
                .Include(o => o.Category)
                .Where(o => o.CategoryId == id)
                .ToListAsync();

            return Ok(products);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Put(
            [FromBody]Product model,
            [FromServices]DataContext context)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o produto" });
            }
        }
    }
}