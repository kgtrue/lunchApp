using HybridDb;
using LunchApp.Core.Contracts;
using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LunchApp.Inferstructure.Persistence.HybridDb.Repositories
{
    public class LunchMenuReviewRepo : IBaseRepo, ILunchMenuReviewRepo
    {
        private readonly DocumentStore context;
        public LunchMenuReviewRepo(DocumentStore context)
        {
            this.context = context;
        }

        public DocumentStore Context => context;

        public IList<LunchMenuReview> GetAllMenuReviews(int menuId)
        {
            using var session = context.OpenSession();
            var entity = session.Query<LunchMenuReview>().Where(x => x.LunchMenu.Id == menuId);
            return entity.ToList();
        }

        public LunchMenuReview GetById(Guid id)
        {
            using var session = context.OpenSession();
            var entity = session.Query<LunchMenuReview>().Single(x => x.Id == id);
            return entity;
        }

        public void SaveUpdate(LunchMenuReview lunchMenu)
        {
            using var session = context.OpenSession();
            var entity = session.Query<LunchMenuReview>().Single(x => x.Id == lunchMenu.Id);

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
