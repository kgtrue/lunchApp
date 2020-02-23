using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts.Dtos
{
    public class CreateLunchMenuResponse : BaseResponse 
    {
        public CreateLunchMenuResponse(bool result, List<string> messages) : base(result, messages)
        {

        }
    }
}
