using LunchApp.Core.Contracts;
using LunchApp.Core.Interactors;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using LunchApp.Core.Entity;
using System.Linq;
namespace LunchApp.Core.Tests.Interactors
{
    public class RateLunchMenuInteractorTest
    {

        public RateLunchMenuInteractorTest()
        {

        }

        [Fact]
        public void TestRateLunchMenuInteractorReviewForNoCource()
        {
            var menmuDate = DateTime.Now.Date;
            var menu = new Menu(menmuDate);
            menu.AddMenuCourse("Test Course 1");
            menu.AddMenuCourse("Test Course 2");
            int reviewToken = 1;
            var courceId1 = menu.Courses[0].Id;
            var courceId2 = menu.Courses[1].Id;

            var reviews = new List<(int courseId, int reviewScore)>
            {
                (courceId1, 1),
                //cource wit id is not in list of  Courses
                (1, 1)
            };

            var menuRepo = new Mock<IMenuRepo>();
            menuRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(menu);
            var interactor = new RateMenuInteractor(menuRepo.Object);

            var response = interactor.Handle(new Contracts.Dtos.RateMenuRequest(menu.Id, reviewToken, reviews));
            Assert.False(response.Result);
            Assert.Contains(response.Messages, e => e == $"Unable to register review for cource with id: {1} and score {1}");
        }

        [Fact]
        public void TestRateLunchMenuInteractorReviewToLarge()
        {
            var menmuDate = DateTime.Now.Date;
            var menu = new Menu(menmuDate);
            menu.AddMenuCourse("Test Course 1");

            int reviewToken = 1;
            var courceId1 = menu.Courses[0].Id;

            var reviews = new List<(int courseId, int reviewScore)>
            {
                (courceId1, 6)
            };

            var menuRepo = new Mock<IMenuRepo>();
            menuRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(menu);
            var interactor = new RateMenuInteractor(menuRepo.Object);

            var response = interactor.Handle(new Contracts.Dtos.RateMenuRequest(menu.Id, reviewToken, reviews));
            Assert.False(response.Result);
            Assert.Contains(response.Messages, e => e == $"Unable to register review for cource with id: {courceId1} and score {6}");
        }

        [Fact]
        public void TestRateLunchMenuInteractorReviewToSmall()
        {
            var menmuDate = DateTime.Now.Date;
            var menu = new Menu(menmuDate);
            menu.AddMenuCourse("Test Course 1");

            int reviewToken = 1;
            var courceId1 = menu.Courses[0].Id;

            var reviews = new List<(int courseId, int reviewScore)>
            {
                (courceId1, -1)
            };

            var menuRepo = new Mock<IMenuRepo>();
            menuRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(menu);
            var interactor = new RateMenuInteractor(menuRepo.Object);

            var response = interactor.Handle(new Contracts.Dtos.RateMenuRequest(menu.Id, reviewToken, reviews));
            Assert.False(response.Result);
            Assert.Contains(response.Messages, e => e == $"Unable to register review for cource with id: {courceId1} and score {-1}");
        }

        [Fact]
        public void TestRateLunchMenuInteractorNewReview()
        {
            var menmuDate = DateTime.Now.Date;
            var menu = new Menu(menmuDate);
            menu.AddMenuCourse("Test Course 1");
            menu.AddMenuCourse("Test Course 2");
            int reviewToken1 = 1;
            int reviewToken2 = 2;
            var courceId1 = menu.Courses[0].Id;

            menu.AddUpdateReview(courceId1, reviewToken1, 1);

            var reviews = new List<(int courseId, int reviewScore)>
            {
                (courceId1, 2),
            };

            var menuRepo = new Mock<IMenuRepo>();
            menuRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(menu);
            var interactor = new RateMenuInteractor(menuRepo.Object);

            var response = interactor.Handle(new Contracts.Dtos.RateMenuRequest(menu.Id, reviewToken2, reviews));
            Assert.True(response.Result);
            Assert.True(menu.Courses.First().CourseReviews.Count() == 2);
        }

        [Fact]
        public void TestRateLunchMenuInteractorUpdateReview()
        {
            var menmuDate = DateTime.Now.Date;
            var menu = new Menu(menmuDate);
            menu.AddMenuCourse("Test Course 1");
            menu.AddMenuCourse("Test Course 2");
            int reviewToken = 1;
            var courceId1 = menu.Courses[0].Id;

            menu.AddUpdateReview(courceId1, reviewToken, 1);

            var reviews = new List<(int courseId, int reviewScore)>
            {
                (courceId1, 2),
            };

            var menuRepo = new Mock<IMenuRepo>();
            menuRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(menu);
            var interactor = new RateMenuInteractor(menuRepo.Object);

            var response = interactor.Handle(new Contracts.Dtos.RateMenuRequest(menu.Id, reviewToken, reviews));
            Assert.True(response.Result);
            Assert.True(menu.Courses.First().CourseReviews.Count() == 1);
            Assert.True(menu.Courses.First().CourseReviews.First().ReviewScore == 2);
        }
    }
}
