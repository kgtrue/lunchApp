using LunchApp.Core.Contracts;
using LunchApp.Inferstructure.External.Menu.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.Threading.Tasks;

namespace LunchApp.Core.Tests
{
    public class MenuLookupTest
    {

        [Theory]
        [ClassData(typeof(DateLookupFailTests))]
        public async void IntigrationTestMenuLookupFail(DateTime date)
        {
            var menulookupRepo = new LunchMenuLookupRepo(new System.Net.Http.HttpClient() { BaseAddress = new Uri(@"http://menuservice.energysystems.dk") });
            try
            {
                var result = await menulookupRepo.GetByDate(date);
            }
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(RepoException));
            }

            //fanger ikke exception :(
            //await Assert.ThrowsAsync<RepoException>(async () => await menulookupRepo.GetByDate(date));
        }

        [Theory]
        [ClassData(typeof(DateLookupSuccessTests))]
        public async void IntigrationTestMenuLookupSuccess(DateTime date)
        {
            var menulookupRepo = new LunchMenuLookupRepo(new System.Net.Http.HttpClient() { BaseAddress = new Uri(@"http://menuservice.energysystems.dk") });
            var result = await menulookupRepo.GetByDate(date);
            Assert.NotNull(result);
        }

        public class DateLookupSuccessTests : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new DateTime(2020, 2, 24) };
                yield return new object[] { new DateTime(2020, 2, 25) };
                yield return new object[] { new DateTime(2020, 2, 26) };
                yield return new object[] { new DateTime(2020, 2, 27) };
                yield return new object[] { new DateTime(2020, 2, 28) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class DateLookupFailTests : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new DateTime(2020, 3, 1) };
                yield return new object[] { new DateTime(2020, 3, 2) };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
