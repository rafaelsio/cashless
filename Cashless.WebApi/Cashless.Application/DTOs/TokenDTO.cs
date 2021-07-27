using System;
namespace Cashless.Application.DTOs
{
    public class TokenDTO
    {
        public TokenDTO()
        {
        }

        public DateTime RegistrationDate { get; set; }
        public int Token { get; set; }
        public int CardId { get; set; }

    }
}
