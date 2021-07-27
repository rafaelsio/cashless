using System;
using System.Collections.Generic;
using Cashless.Application.DTOs;
using Cashless.Domain.Entities;

namespace Cashless.Application.Mappers
{
    public static class CreditCardMapper
    {
        public static CreditCard Mapper(this CreditCardDTO creditCardDto)
        {
            return new CreditCard()
            {
                CardNumber = creditCardDto.CardNumber,
                CustomerId = creditCardDto.CustomerId,
                Id = creditCardDto.Id,
                CVV = creditCardDto.CVV
               
            };
        }

        public static CreditCardDTO Mapper(this CreditCard creditCardEntity)
        {
            return new CreditCardDTO()
            {
                CardNumber = creditCardEntity.CardNumber,
                CustomerId = creditCardEntity.CustomerId,
                Id = creditCardEntity.Id,
                CVV = creditCardEntity.CVV
            };
        }

        public static List<CreditCardDTO> Mapper(this List<CreditCard> listCreditCardEntity)
        {
            var retorno = new List<CreditCardDTO>();

            listCreditCardEntity.ForEach(cc=> retorno.Add(cc.Mapper()));

            return retorno;
        }

    }
}
