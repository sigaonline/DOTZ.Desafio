using DOTZ.Desafio.Model.Extensions;
using System;
using System.Collections.Generic;

namespace DOTZ.Desafio.Model.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(Enum message, Dictionary<string, string> keys)
            : base(message.GetDescription())
        {
            Keys = keys ?? new Dictionary<string, string>();
            Code = message;
        }

        public BusinessException(Enum message)
            : base(message.GetDescription())
        {
            Code = message;
        }

        public BusinessException(Enum key, string message)
            : base(message)
        {
            Code = key;
        }

        public Dictionary<string, string> Keys { get; }
        public Enum Code { get; }
    }
}
