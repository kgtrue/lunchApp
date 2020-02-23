using HybridDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunchApp.Inferstructure.Persistence.HybridDb.Repositories
{
    public interface IBaseRepo
    {
        DocumentStore Context { get; }
    }
}
