
using Cashless.Domain.Entities;
using Cashless.Domain.ValueObjects;
using Xunit;

namespace Cashless.Test
{
    public class CreditCartTests
    {

        [Fact]
        public void Calculate_Token_Zero_Rotation()
        {
            
            var creditCard = new CreditCard()
            {
                CardNumber = "123423432420421",
                CustomerId = 1,
                CVV="0020"
            };

            var token = new Token();
            token.GenerateToken(creditCard);
            int result = token.TokenNumber;
            

            Assert.Equal<int>(421, result);
        }

        [Fact]
        public void Calculate_Token_One_Rotation()
        {

            var creditCard = new CreditCard()
            {
                CardNumber = "123423432420421",
                CustomerId = 1,
                CVV = "0021"
            };

            var token = new Token();
            token.GenerateToken(creditCard);
            int result = token.TokenNumber;

            Assert.Equal<int>(1042, result);
        }


        [Fact]
        public void Calculate_Token_Two_Rotation()
        {

            var creditCard = new CreditCard()
            {
                CardNumber = "123423432420421",
                CustomerId = 1,
                CVV = "0022"
            };

            var token = new Token();
            token.GenerateToken(creditCard);
            int result = token.TokenNumber;

            Assert.Equal<int>(2104, result);
        }


        [Fact]
        public void Calculate_Token_Three_Rotation()
        {

            var creditCard = new CreditCard()
            {
                CardNumber = "123423432420421",
                CustomerId = 1,
                CVV = "0023"
            };

            var token = new Token();
            token.GenerateToken(creditCard);
            int result = token.TokenNumber;

            Assert.Equal<int>(4210, result);
        }

        [Fact]
        public void Calculate_Token_Four_Rotation()
        {

            var creditCard = new CreditCard()
            {
                CardNumber = "123423432420421",
                CustomerId = 1,
                CVV = "0024"
            };

            var token = new Token();
            token.GenerateToken(creditCard);
            int result = token.TokenNumber;

            Assert.Equal<int>(421, result);
        }

    }
}
