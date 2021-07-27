using Cashless.Application.Contracts;
using Cashless.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Cashless.WebApi.Extentions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cashless.Common;
using System.Net;

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
        /// <summary>
        /// Retrives complet credit cards data
        /// </summary>
        /// <param name="customerId">Customer Id (mandatory)</param>
        /// <param name="cardId">Id CreditCard (mandatory)</param>
        /// <param name="token">Token (mandatory)</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Result<CreditCardDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result<CreditCardDTO>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<CreditCardDTO>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetCreditCard([FromQuery] int customerId, [FromQuery] int cardId, [FromQuery]int token)
        {
            var response = await _creditCardService.GetCreditCard(customerId,cardId, token);
            return this.GetHttpResponse<CreditCardDTO>(response);
        }
        /// <summary>
        /// Verify if the token is valid for the credit card
        /// </summary>
        /// <param name="customerId">Customer Id (mandatory)</param>
        /// <param name="cardId">Credit Cart Id (mandatory)</param>
        /// <param name="token">Token (mandatory)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/token")]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<bool>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ValidCreditCard([FromQuery] int customerId, [FromQuery] int cardId, [FromQuery] int token)
        {
            var response = await _creditCardService.ValidateCreditCardToken(customerId, cardId, token);
            return this.GetHttpResponse<bool>(response);
        }

        /// <summary>
        /// Create a new credit card e return the token
        /// </summary>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result<TokenDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Result<TokenDTO>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Result<TokenDTO>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SaveCreditCard([FromBody]CreditCardDTO creditCard)
        {
            var response = await _creditCardService.SaveCreditCard(creditCard);
            return this.GetHttpResponse<TokenDTO>(response);
        }


    }
}
