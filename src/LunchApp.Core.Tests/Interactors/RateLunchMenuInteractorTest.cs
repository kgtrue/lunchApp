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
        private readonly Mock<IMenuRepo> lunchMenuRepo = new Mock<IMenuRepo>();
        public RateLunchMenuInteractorTest()
        {
            lunchMenuRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Menu(DateTime.Now) { });
        }

        public void TestRateLunchMenuInteractorFail(int menuId, List<(int DishId, int ReviewScore)> reviews)
        {
            var interactor = new RateMenuInteractor(lunchMenuRepo.Object);
            var response = interactor.Handle(new Contracts.Dtos.RateMenuRequest(menuId, 1, reviews));
            Assert.False(response.Result);
        }
    }
}
