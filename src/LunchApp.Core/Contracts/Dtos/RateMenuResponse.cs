using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts.Dtos
{
    public class RateMenuResponse : BaseResponse
    {
        public RateMenuResponse(bool result, List<string> messages) : base(result, messages)
        {

        }
    }
}
