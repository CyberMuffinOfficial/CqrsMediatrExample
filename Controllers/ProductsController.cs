using CqrsMediatrExample.Commands;
using CqrsMediatrExample.Entities;
using CqrsMediatrExample.Notifications;
using CqrsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly IMediator _mediator;
        private readonly ISender _sender;
        private readonly IPublisher _publisher; // this is needed in order to publish notifications

        public ProductsController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(product));

            await _publisher.Publish(new ProductAddedNotification(productToReturn)); // can also do this in the handler for AddProductCommand
            //return StatusCode(201);
            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }


    }
}
