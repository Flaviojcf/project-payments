using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Models;
using Payments.API.Services;

namespace Payments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentService paymentService) : ControllerBase
    {
        private readonly IPaymentService _paymentService = paymentService;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentInfoInputModel paymentInfoInputModel)
        {
            var result = await _paymentService.Process(paymentInfoInputModel);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
