using System;
using System.ComponentModel.DataAnnotations.Schema;
using Cashless.Common;
using Cashless.Common.Extentions;
using Cashless.Domain.Entities;

namespace Cashless.Domain.ValueObjects
{
    public class Token
    {
        public int Id { get; set; }
        private int _tokenNumber;
        private DateTime _registrationDate;
        [ForeignKey("CreditCardId")]
        private CreditCard _creditCard;

        public int TokenNumber
        {
            get
            {
                return _tokenNumber;
            }
        }

        public DateTime RegistrationDate
        {
            get
            {
                return _registrationDate;
            }
        }

        public int CreditCardId
        {
            get
            {
                return _creditCard.Id;
            }
        }

        public void GenerateToken(CreditCard creditCard)
        {
            this._creditCard = creditCard;
            this._tokenNumber = CalculateToken(this._creditCard.CardNumber, this._creditCard.CVV);
            this._registrationDate = DateTime.UtcNow;

        }

        private int CalculateToken(string cardNumber, string CVV)
        {

            string last4digits = cardNumber.Substring(cardNumber.Length - 4);
            var last4digitsArray = last4digits.convertToIntArray();
            int cvv = CVV.convertToInt();

            int maxRotations = cvv % last4digitsArray.Length;

            for (int x = 1; x <= maxRotations; x++)
            {
                last4digitsArray = last4digitsArray.RightCirculation();

            }

            return last4digitsArray.ConvertArrayToNumber();
        }

        public bool isExpired()
        {
            return _registrationDate.AddMinutes(30) > DateTime.UtcNow;
        }

        public Result<bool> ValidateToken(string cardNumber, string CVV, int tokenToCompare)
        {

            if(isExpired())
            {
                return new Result<bool>() { ErrorCode = ErrorCode.CC_009, ErrorType = ErrorType.Validation };
            }

            int calcultedToken = CalculateToken(cardNumber, CVV);
            if (calcultedToken != tokenToCompare)
            {
                return new Result<bool>() { ErrorCode = ErrorCode.CC_009, ErrorType = ErrorType.Validation };
            }

            return new Result<bool>(){ Data=true };

        }
    }
}
