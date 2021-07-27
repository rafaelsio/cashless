using System;
using Cashless.Application.Contracts;
using Cashless.Application.DTOs;
using Cashless.Infrastructure.DI;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Cashless.Test
{
    public class CreditCardServiceTests
    {
        private ICreditCardService _creditCardService;
        public CreditCardServiceTests()
        {
            var services = new ServiceCollection();
            var serviceProvider = DepencyInjection.Register(services);

            _creditCardService = serviceProvider.GetService<ICreditCardService>();


        }

        [Fact]
        public void Create_Credit_Card_With_Valid_Token()
        {
            var creditCardDTO = new CreditCardDTO()
            {
                CardNumber = "123400023422301",
                CustomerId = 1,
                CVV="220"
            };

            var resultSaveCreditCard = _creditCardService.SaveCreditCard(creditCardDTO).Result;

            var resultValidation = _creditCardService.ValidateCreditCardToken(1, resultSaveCreditCard.Data.CardId, 2301).Result;


            Assert.True(resultSaveCreditCard.Valid());
            Assert.True(resultValidation.Valid());

        }

        [Fact]
        public void Create_Credit_Card_With_Invalid_Token()
        {
            var creditCardDTO = new CreditCardDTO()
            {
                CardNumber = "123400023422301",
                CustomerId = 1,
                CVV = "223"
            };

            var resultSaveCreditCard = _creditCardService.SaveCreditCard(creditCardDTO).Result;

            var resultValidation = _creditCardService.ValidateCreditCardToken(1, resultSaveCreditCard.Data.CardId, 2301).Result;


            Assert.True(resultSaveCreditCard.Valid());
            Assert.False(resultValidation.Valid());

        }
    }
}
