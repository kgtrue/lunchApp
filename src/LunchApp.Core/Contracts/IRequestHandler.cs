﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts
{
    public interface IRequestHandler<in TRequest, out TResponse> where TRequest : IRequest<TResponse>
    {
        TResponse Handle(TRequest message);
    }
    public interface IRequestHandler<in TRequest> where TRequest : IRequest
    {
        void Handle(TRequest message);
    }
}
