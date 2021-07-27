using System;
using Cashless.Application.DTOs;
using Cashless.Domain.Entities;
using Cashless.Domain.ValueObjects;

namespace Cashless.Application.Mappers
{
    public static class TokenMapper
    {
        public static TokenDTO Mapper(this Token tokenEntity)
        {
            var token = new TokenDTO()
            {
                CardId = tokenEntity.CreditCardId,
                RegistrationDate = tokenEntity.RegistrationDate,
                Token = tokenEntity.TokenNumber
            };

            return token;
        }
    }
}
