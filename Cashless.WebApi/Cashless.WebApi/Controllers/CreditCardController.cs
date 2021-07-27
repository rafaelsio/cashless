using Cashless.Application.Contracts;
using Cashless.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Cashless.WebApi.Extentions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cashless.Common;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cashless.WebApi.Controllers
{
    [ApiController]
    [Route("creditcard")]
    public class CreditCardController : Controller
    {
        private ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCreditCard([FromQuery] int customerId, [FromQuery] int cardId, [FromQuery]int token)
        {
            var response = await _creditCardService.GetCreditCard(customerId,cardId, token);
            return this.GetHttpResponse<CreditCardDTO>(response);
        }

        [HttpGet]
        [Route("/token")]
        public async Task<IActionResult> ValidaCreditCard([FromQuery] int customerId, [FromQuery] int cardId, [FromQuery] int token)
        {
            var response = await _creditCardService.ValidateCreditCardToken(customerId, cardId, token);
            return this.GetHttpResponse<bool>(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCreditCard([FromBody]CreditCardDTO creditCard)
        {
            var response = await _creditCardService.SaveCreditCard(creditCard);
            return this.GetHttpResponse<TokenDTO>(response);
        }


    }
}
