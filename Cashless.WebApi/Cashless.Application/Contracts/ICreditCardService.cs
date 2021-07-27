using System.Collections.Generic;
using System.Threading.Tasks;
using Cashless.Application.DTOs;
using Cashless.Common;

namespace Cashless.Application.Contracts
{
    public interface ICreditCardService
    {
        Task<Result<TokenDTO>> SaveCreditCard(CreditCardDTO creditCard);
        Task<Result<CreditCardDTO>> GetCreditCard(int customerId,int cardId, int token);
        Task<Result<bool>> ValidateCreditCardToken(int customerId, int cardId, int token);
    }
}
