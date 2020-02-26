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

        public void CopyValues<T>(T target, T source)
        {
            Type t = typeof(T);
            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);
            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                    prop.SetValue(target, value, null);
            }
        }

        public void SaveUpdate(Menu menu)
        {
            using var session = documentStore.OpenSession();
            var entity = session.Query<Menu>().SingleOrDefault(x => x.Id == menu.Id);

            if (entity == null)
            {
                entity = menu;
                session.Store(entity);
            }

            if (!entity.Equals(menu))
            {
                CopyValues(entity, menu);
            }

            session.SaveChanges();
        }
    }
}
