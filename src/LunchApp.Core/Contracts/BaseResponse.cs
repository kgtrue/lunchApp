using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts
{
    public abstract class BaseResponse
    {
        public BaseResponse(bool result, IList<string> messages)
        {
            _ = messages ?? throw new NullReferenceException("Meseages must not be null ");
            Result = result;
            Messages = messages; 
        }

        public bool Result { get; private set;}
        public  IList<string> Messages { get; private set; }
    }
}
