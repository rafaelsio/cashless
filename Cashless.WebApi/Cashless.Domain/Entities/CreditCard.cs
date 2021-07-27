using System.ComponentModel.DataAnnotations.Schema;
using Cashless.Common;
using Cashless.Common.Extentions;
using Cashless.Domain.ValueObjects;

namespace Cashless.Domain.Entities
{
    public class CreditCard
    {
        public CreditCard()
        {

        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public Token Token { get; set; }


        public Result<bool> Valid()
        {
            if (CustomerId == default(int))
            {
                return new Result<bool>() { Data = false, ErrorCode = ErrorCode.CC_001, ErrorType = ErrorType.Validation };
            }

            if (string.IsNullOrEmpty(CardNumber))
            {
                return new Result<bool>() { Data = false, ErrorCode = ErrorCode.CC_003, ErrorType = ErrorType.Validation };
            }

            if (CardNumber.Length > 16)
            {
                return new Result<bool>() { Data = false, ErrorCode = ErrorCode.CC_004, ErrorType = ErrorType.Validation };
            }

            if (!CardNumber.onlyNumbers())
            {
                return new Result<bool>() { Data = false, ErrorCode = ErrorCode.CC_006, ErrorType = ErrorType.Validation };
            }

            if (CVV.Length > 5)
            {
                return new Result<bool>() { Data = false, ErrorCode = ErrorCode.CC_008, ErrorType = ErrorType.Validation };
            }

            if (!CVV.onlyNumbers())
            {
                return new Result<bool>() { Data = false, ErrorCode = ErrorCode.CC_007, ErrorType = ErrorType.Validation };
            }


            return new Result<bool>() { Data = true };
        }
    }

}
