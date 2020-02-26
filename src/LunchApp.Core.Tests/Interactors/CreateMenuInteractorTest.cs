using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using LunchApp.Core.Contracts;
using LunchApp.Core.Entity;
using LunchApp.Core.Interactors;
using LunchApp.Inferstructure.External.Menu.Api.Dtos;
using LunchApp.Inferstructure.External.Menu.Api.Entity;
using System.Threading.Tasks;

namespace LunchApp.Core.Tests.Interactors
{
    public class CreateMenuInteractorTest
    {
        public CreateMenuInteractorTest()
        {

        }
        [Fact]
        public void TestRateLunchMenuInteractorLookupSuccess()
        {
            var menuDate = DateTime.Now.Date;
            var mockMenuRepo = new Mock<IMenuRepo>();
            var moclLunchMenuLookupRepo = new Mock<ILunchMenuLookupRepo>();
            mockMenuRepo.Setup(a => a.GetById(It.IsAny<int>())).Returns(() => null);

            moclLunchMenuLookupRepo.Setup(a => a.GetByDate(It.IsAny<DateTime>())).ReturnsAsync(new MenuResponse() { Menu = new ExternalMenu() { Date = menuDate, Course = new string[] { "Text cource" } }, Result = true });
            var interactor = new CreateMenuInteractor(mockMenuRepo.Object, moclLunchMenuLookupRepo.Object);
            var response = interactor.Handle(new Contracts.Dtos.CreateMenuRequest(menuDate));
            Assert.True(response.Result);
        }

        [Fact]
        public void TestCreateMenuInteractorMenuExistsSuccess()
        {
            var menuDate = DateTime.Now.Date;
            var mockMenuRepo = new Mock<IMenuRepo>();
            var moclLunchMenuLookupRepo = new Mock<ILunchMenuLookupRepo>();
            mockMenuRepo.Setup(a => a.GetById(It.IsAny<int>())).Returns(() => new Menu(menuDate));

            moclLunchMenuLookupRepo.Setup(a => a.GetByDate(It.IsAny<DateTime>())).ReturnsAsync(new MenuResponse() { Menu = new ExternalMenu() { Date = menuDate, Course = new string[] { "Text cource" } }, Result = true });
            var interactor = new CreateMenuInteractor(mockMenuRepo.Object, moclLunchMenuLookupRepo.Object);
            var response = interactor.Handle(new Contracts.Dtos.CreateMenuRequest(menuDate));
            Assert.False(response.Result);
        }

        [Fact]
        public void TestCreateMenuInteractorMenuCourceDublicates()
        {
            var menuDate = DateTime.Now.Date;
            var mockMenuRepo = new Mock<IMenuRepo>();
            var moclLunchMenuLookupRepo = new Mock<ILunchMenuLookupRepo>();
            mockMenuRepo.Setup(a => a.GetById(It.IsAny<int>())).Returns(() => new Menu(menuDate));

            moclLunchMenuLookupRepo.Setup(a => a.GetByDate(It.IsAny<DateTime>())).ReturnsAsync(new MenuResponse() { Menu = new ExternalMenu() { Date = menuDate, Course = new string[] { "Text cource", "Text cource" } }, Result = true });
            var interactor = new CreateMenuInteractor(mockMenuRepo.Object, moclLunchMenuLookupRepo.Object);
            var response = interactor.Handle(new Contracts.Dtos.CreateMenuRequest(menuDate));
            Assert.False(response.Result);
        }


        [Fact]
        public void TestCreateMenuInteractorLookupFail()
        {
            var menuDate = DateTime.Now.Date;
            var mockMenuRepo = new Mock<IMenuRepo>();
            var moclLunchMenuLookupRepo = new Mock<ILunchMenuLookupRepo>();
            mockMenuRepo.Setup(a => a.GetById(It.IsAny<int>())).Returns(() => new Menu(menuDate));
            moclLunchMenuLookupRepo.Setup(a => a.GetByDate(It.IsAny<DateTime>())).ReturnsAsync(new MenuResponse() { Menu = null, Result = false });
            var interactor = new CreateMenuInteractor(mockMenuRepo.Object, moclLunchMenuLookupRepo.Object);
            var response = interactor.Handle(new Contracts.Dtos.CreateMenuRequest(menuDate));
            Assert.False(response.Result);
        }
    }
}
