using System;
using System.ComponentModel;

namespace Cashless.Common
{
    public enum ErrorCode
    {
        [Description("Customer Id was not informed")]
        CC_001,

        [Description("There is not creditCard for this customer")]
        CC_002,

        [Description("Credit card is empty")]
        CC_003,

        [Description("Credit card number has more than 16 caracters")]
        CC_004,

        [Description("Credit card number already exists")]
        CC_005,

        [Description("Credit card number must be only numbers")]
        CC_006,

        [Description("Credit card CVV must be only numbers")]
        CC_007,

        [Description("Credit card CVV has more than 5 caracters")]
        CC_008,

        [Description("Token expired")]
        CC_009,

        [Description("Token is invalid")]
        CC_010,

    }
}
