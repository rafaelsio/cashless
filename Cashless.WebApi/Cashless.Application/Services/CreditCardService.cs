
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cashless.Application.Contracts;
using Cashless.Application.DTOs;
using Cashless.Application.Mappers;
using Cashless.Common;
using Cashless.Domain.Entities;
using Cashless.Domain.Repositories;
using System.Linq;
using Cashless.Domain.ValueObjects;

namespace Cashless.Application.Services
{
    public class CreditCardService : ICreditCardService
    {
        public ICreditCardRepository _creditCardRepostiory;
        public CreditCardService(ICreditCardRepository creditCardRepostiory)
        {
            _creditCardRepostiory = creditCardRepostiory;
        }

        public async Task<Result<CreditCardDTO>> GetCreditCard(int customerId, int cardId, int token)
        {
            try
            {

                if (customerId == default(int))
                {
                    return new Result<CreditCardDTO>() { ErrorType = ErrorType.Validation, ErrorCode = ErrorCode.CC_001 };
                }

                var data = await _creditCardRepostiory.GetCustomerCreditCard(customerId, cardId);

                if (data != null)
                {
                    if(data.Token.TokenNumber == token)
                        return new Result<CreditCardDTO>() { Data = data.Mapper() };
                    else
                        return new Result<CreditCardDTO>() { ErrorCode = ErrorCode.CC_010, ErrorType = ErrorType.Validation };
                }
                else
                {
                    return new Result<CreditCardDTO>() { ErrorType = ErrorType.Validation, ErrorCode = ErrorCode.CC_002 };
                }
            }
            catch (Exception ex)
            {
                return new Result<CreditCardDTO>() { ErrorType = ErrorType.Application, Message = ex.Message };
            }
        }

        public async Task<Result<TokenDTO>> SaveCreditCard(CreditCardDTO creditCardDTO)
        {
            try
            {
                var creditCard = creditCardDTO.Mapper();

                var validationCreditCardResult = creditCard.Valid();

                if (!validationCreditCardResult.Valid())
                {
                    return new Result<TokenDTO>() { ErrorCode = validationCreditCardResult.ErrorCode, ErrorType= validationCreditCardResult.ErrorType };
                }

                var verifyCreditCardNumberExists = await _creditCardRepostiory.GetCreditCardByNumber(creditCard.CardNumber);
                if (verifyCreditCardNumberExists != null)
                {
                    return new Result<TokenDTO>() { ErrorCode = ErrorCode.CC_005, ErrorType = ErrorType.Validation };
                }

                if (creditCard.Token == null)
                {
                    Token token = new Token();
                    token.GenerateToken(creditCard);
                    creditCard.Token = token;
                }

                await _creditCardRepostiory.SaveCreditCard(creditCard);

                return new Result<TokenDTO>() { Data = creditCard.Token.Mapper() };
            }
            catch(Exception ex)
            {
                return new Result<TokenDTO>() { ErrorType = ErrorType.Application, Message = ex.Message };
            }
        }

        public async Task<Result<bool>> ValidateCreditCardToken(int customerId, int cardId, int token)
        {
            var creditCardResult = await this.GetCreditCard(customerId, cardId, token);

            if (creditCardResult.Valid())
            {
                return new Result<bool>() { Data = true };
            }
            else
                return new Result<bool>() { ErrorCode = creditCardResult.ErrorCode, ErrorType = creditCardResult.ErrorType };
            
        }


    }
}
