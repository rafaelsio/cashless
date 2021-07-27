using System;
namespace Cashless.Application.DTOs
{
    public class CreditCardDTO
    {

        public CreditCardDTO()
        {

        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string  CVV { get; set; }
    }
}
