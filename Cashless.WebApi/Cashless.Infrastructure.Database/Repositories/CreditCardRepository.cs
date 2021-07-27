using System;
using System.Collections.Generic;
using Cashless.Domain.Entities;
using Cashless.Domain.Repositories;
using Cashless.Infrastructure.Database.EFContext;
using System.Linq;
using System.Threading.Tasks;

namespace Cashless.Infrastructure.Database.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private CreditCardContext _creditCardContext;
        public CreditCardRepository(CreditCardContext creditCardContext)
        {
            _creditCardContext = creditCardContext;
        }
        public async Task<CreditCard> GetCreditCardByNumber(string number)
        {
            return _creditCardContext.Cards.Where(cc => cc.CardNumber == number).FirstOrDefault();
        }
        

        public async Task<CreditCard> GetCustomerCreditCard(int customerId, int creditCardId)
        {
            return _creditCardContext.Cards.Where(cc => cc.CustomerId == customerId && cc.Id ==creditCardId ).FirstOrDefault();
        }

        public async Task SaveCreditCard(CreditCard creditCard)
        {
            if (creditCard.Id <= 0)
                creditCard.Id = _creditCardContext.Cards.Count()+1;

            _creditCardContext.Add(creditCard);
            _creditCardContext.SaveChanges();
        }
    }
}
