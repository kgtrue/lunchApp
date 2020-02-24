using HybridDb;
using LunchApp.Core.Contracts;
using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LunchApp.Inferstructure.Persistence.HybridDb.Repositories
{
    public class LunchMenuRepo :  ILunchMenuRepo
    {
        private readonly IDocumentStore documentStore;
        public LunchMenuRepo(IDocumentStore documentStore)
        {
            this.documentStore = documentStore;
        }       

        public LunchMenu GetById(int id)
        {
            using var session = documentStore.OpenSession();
            var entity = session.Query<LunchMenu>().Single(x => x.Id == id);
            return entity;
        }

        public void SaveUpdate(LunchMenu lunchMenu)
        {
            using var session = documentStore.OpenSession();
            var entity = session.Query<LunchMenu>().Single(x => x.Id == lunchMenu.Id);

            if (entity == null)
            {
                session.Store(lunchMenu);
            }
            else
            {
                entity = lunchMenu;
            }

            session.SaveChanges();
        }
    }
}
