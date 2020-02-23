using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Core.Contracts
{
    public class RepoException : Exception
    {
        public RepoException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
