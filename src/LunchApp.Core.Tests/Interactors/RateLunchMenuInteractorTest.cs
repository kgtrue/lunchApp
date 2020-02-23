using LunchApp.Core.Contracts;
using LunchApp.Core.Interactors;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using LunchApp.Core.Entity;

namespace LunchApp.Core.Tests.Interactors
{
    public class RateLunchMenuInteractorTest
    {
        private readonly Mock<ILunchMenuRepo> lunchMenuRepo = new Mock<ILunchMenuRepo>();
        private readonly Mock<ILunchMenuReviewRepo> lunchMenuReviewRepo = new Mock<ILunchMenuReviewRepo>();
        public RateLunchMenuInteractorTest()
        {
            lunchMenuRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(new LunchMenu(DateTime.Now) { });
            lunchMenuReviewRepo.Setup(x => x.SaveUpdate(It.IsAny<LunchMenuReview>())).Throws<LunchMenureviewSaveUpdateException>();
        }

        public void TestRateLunchMenuInteractorFail(int menuId, List<(int DishId, uint ReviewScore)> reviews)
        {
            var interactor = new RateLunchMenuInteractor(lunchMenuRepo.Object, lunchMenuReviewRepo.Object);
            var response = interactor.Handle(new Contracts.Dtos.RateLunchMenuRequest(menuId ,reviews));
            Assert.False(response.Result);
        }
    }
}
