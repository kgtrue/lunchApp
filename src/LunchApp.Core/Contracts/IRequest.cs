using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts
{
    public interface IRequest
    {
    }

    public interface IRequest<out TResponse>
    {
    }
}
