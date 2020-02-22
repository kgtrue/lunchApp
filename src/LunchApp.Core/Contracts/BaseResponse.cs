using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts
{
    public abstract class BaseResponse
    {
        public BaseResponse(bool result, IList<string> meseages)
        {
            _ = meseages ?? throw new NullReferenceException("Meseages must not be null ");
            Result = result;
            Meseages = meseages; 
        }

        public bool Result { get; private set;}
        public  IList<string> Meseages { get; private set; }
    }
}
