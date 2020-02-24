using HybridDb;
using LunchApp.Core.Contracts;
using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LunchApp.Inferstructure.Persistence.HybridDb.Repositories
{
    public class LunchMenuRepo : IMenuRepo
    {
        private readonly IDocumentStore documentStore;
        public LunchMenuRepo(IDocumentStore documentStore)
        {
            this.documentStore = documentStore;
        }

        public Menu GetById(int id)
        {            
                 using var session = documentStore.OpenSession();
                 var entity = session.Query<Menu>().SingleOrDefault(x => x.Id == id);
                 return entity;
        }

        public void SaveUpdate(Menu lunchMenu)
        {
            using var session = documentStore.OpenSession();
            var entity = session.Query<Menu>().SingleOrDefault(x => x.Id == lunchMenu.Id);

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
