using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts.Dtos
{
    public class RateLunchMenuResponse : BaseResponse
    {
        public RateLunchMenuResponse(bool result, List<string> messages) : base(result, messages)
        {

        }
    }
}
