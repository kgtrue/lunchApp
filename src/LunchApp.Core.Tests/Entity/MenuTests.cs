using LunchApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
namespace LunchApp.Core.Tests.Entity
{
    public class MenuTests
    {
        [Fact]
        public void MenuAddCourceSuccess()
        {
            var menu = new Menu(DateTime.Now);
            Assert.True(menu.AddMenuCourse("New"));
        }

        [Fact]
        public void MenuAddCourceWithItemsSuccess()
        {
            var menu = new Menu(DateTime.Now);
            menu.AddMenuCourse("New1");
            Assert.True(menu.AddMenuCourse("New2"));
        }

        [Fact]
        public void MenuAddCourceFail()
        {
            var menu = new Menu(DateTime.Now);
            menu.AddMenuCourse("New");
            Assert.False(menu.AddMenuCourse("New"));
        }

        [Fact]
        public void MenuAddReviewScoreSuccess()
        {
            var menu = new Menu(DateTime.Now);
            menu.AddMenuCourse("New");
            var cource = menu.Courses.First();
            Assert.True(menu.AddUpdateReview(cource.Id, 1, 0));
        }

        [Fact]
        public void MenuAddReviewScoreToLargeFail()
        {
            var menu = new Menu(DateTime.Now);
            menu.AddMenuCourse("New");
            var cource = menu.Courses.First();
            Assert.False(menu.AddUpdateReview(cource.Id, 1, 6));
        }
        [Fact]
        public void MenuAddReviewScoreToSmallFail()
        {
            var menu = new Menu(DateTime.Now);
            menu.AddMenuCourse("New");
            var cource = menu.Courses.First();
            Assert.False(menu.AddUpdateReview(cource.Id, 1, -1));
        }

        [Fact]
        public void MenuAddReviewScoreNoCourseFail()
        {
            var menu = new Menu(DateTime.Now);
            menu.AddMenuCourse("New");
            var cource = menu.Courses.First();
            Assert.False(menu.AddUpdateReview(1, 1, 6));
        }

        [Fact]
        public void MenuAddReviewScoreUpdateSuccess()
        {
            var menu = new Menu(DateTime.Now);
            menu.AddMenuCourse("New");
            var cource = menu.Courses.First();
            menu.AddUpdateReview(cource.Id, 1, 1);
            var review = cource.CourseReviews.First();
            menu.AddUpdateReview(cource.Id, 1, 2);
            Assert.True(cource.CourseReviews.Count()==1 && cource.CourseReviews.First().ReviewScore == 2 );
        }

        [Fact]
        public void MenuAddReviewScoreMultireviewSuccess()
        {
            var menu = new Menu(DateTime.Now);
            menu.AddMenuCourse("New");
            var cource = menu.Courses.First();
            menu.AddUpdateReview(cource.Id, 1, 1);
            var review = cource.CourseReviews.First();
            menu.AddUpdateReview(cource.Id, 2, 2);
            Assert.True(cource.CourseReviews.Count() == 2);
        }

    }
}
