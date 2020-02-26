using HybridDb;
using LunchApp.Core.Contracts;
using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LunchApp.Inferstructure.Persistence.HybridDb.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly IDocumentStore documentStore;
        public ReviewRepo(IDocumentStore documentStore)
        {
            this.documentStore = documentStore;
        }
        public IList<CourseReview> GetAllMenuReviews(int menuId)
        {
            using var session = documentStore.OpenSession();
            var entity = session.Query<Menu>().Single(x => x.Id == menuId);
            return entity.Courses.SelectMany(cr => cr.CourseReviews).ToList();
        }
    }
}
