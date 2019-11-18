using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storev3.Contracts.V1.Requests;
using Storev3.Contracts.V1.Responses;
using Storev3.Models;
using Storev3.Services;

namespace Storev3.Controllers.V1
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("apiV1/products")]
        public IActionResult GetAll()
        {
            //var response = new List<ProductResponse>();
            //foreach (var item in productsService.GetAll())
            //{
            //    response.Add(new ProductResponse
            //    {
            //        Id = item.Id,
            //        Name = item.Name
            //    });

            //}
            var response = productsService.GetAll().Select(x => new ProductResponse { Id = x.Id, Name = x.Name });
            return Ok(response);
        }
        [HttpGet("apiV1/products/{id}")]
        public IActionResult GetProduct([FromRoute]Guid Id)
        {

            var product = productsService.GetProduct(Id);
            if (product==null)
            {
                return NotFound();
            }
            var prodResponse = new ProductResponse { Id = product.Id, Name = product.Name };
            return Ok(prodResponse);
        }
        [HttpPost("apiV1/products/")]
        public IActionResult AddProduct([FromBody]ProductRequest productRequest)
        {
            var product = productsService.AddProduct(productRequest.Name);
            var prodResponse = new ProductResponse { Id = product.Id, Name = product.Name };

            return CreatedAtAction(nameof(GetProduct),new {Id= prodResponse.Id, prodResponse });
        }
    }
}