using System;
using System.Runtime.Serialization;
using Cashless.Common.Extentions;

namespace Cashless.Common
{
    public class Result<T>
    {
        [DataMember]
        public ErrorCode? ErrorCode { get; set; }

        [DataMember]
        public ErrorType? ErrorType { get; set; }

        [DataMember]
        public T Data { get; set; }

        [DataMember]
        public string Message { get; set; }
        

        public bool Valid()
        {
            return !this.ErrorCode.HasValue;
        }

        public string Detail()
        {
            return ErrorCode.GetDescription();
        }
    }
}
