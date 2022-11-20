using Category.API.Entities;
using Category.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Category.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryRepository repository, ILogger<CategoryController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PaymentCategory>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PaymentCategory>>> GetPaymentCategories()
        {
            var products = await _repository.GetPaymentCategories();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetPaymentCategory")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(PaymentCategory), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaymentCategory>> GetPaymentCategoryById(string id)
        {
            var product = await _repository.GetPaymentCategory(id);

            if (product == null)
            {
                _logger.LogError($"Payment Category with id: {id}, not found.");
                return NotFound();
            }

            return Ok(product);
        }

        [Route("[action]/{name}", Name = "GetPaymentCategoryByName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<PaymentCategory>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaymentCategory>> GetPaymentCategoryByName(string name)
        {
            var items = await _repository.GetPaymentCategoryByName(name);
            if (items == null)
            {
                _logger.LogError($"Payment Category with name: {name} not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaymentCategory), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaymentCategory>> CreateProduct([FromBody] PaymentCategory category)
        {
            await _repository.CreatePaymentCategory(category);

            return CreatedAtRoute("GetPaymentCategory", new { id = category.Id }, category);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PaymentCategory), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] PaymentCategory category)
        {
            return Ok(await _repository.UpdatePaymentCategory(category));
        }

        [HttpDelete("{id:length(24)}", Name = "DeletePaymentCategory")]
        [ProducesResponseType(typeof(PaymentCategory), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePaymentCategoryById(string id)
        {
            return Ok(await _repository.DeletePaymentCategory(id));
        }
    }
}
