using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cashless.Domain.Entities;

namespace Cashless.Domain.Repositories
{
    public interface ICreditCardRepository
    {
        public Task<CreditCard> GetCreditCardByNumber(string number);
        public Task SaveCreditCard(CreditCard creditCard);
        public Task<CreditCard> GetCustomerCreditCard(int customerId, int creditCardId);
        
    }
}
