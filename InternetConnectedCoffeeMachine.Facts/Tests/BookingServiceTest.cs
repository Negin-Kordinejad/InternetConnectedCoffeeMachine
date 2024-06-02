using RideBooking.Infrastructure.Models;

namespace RideBooking.Service.Test.Tests
{
    [TestClass]
    public class BookingServiceTest : FunctionalTestBase
    {
        [TestMethod]
        [DynamicData(nameof(ApplyDataForNullTestCases))]
        public async Task GetListingAsync_WhenListingNotExists_ReturnNotFound(int passenger, string? name)
        {
            //Arrange
            BookingApiAgent.ConfigureGetListingByPassengersAsyncToReturn(null);

            //Act
            var result = await BookingService.GetListingAsync(passenger, name);

            //Assert
            Assert.IsFalse(result.IsSuccessful);
            Assert.IsTrue(result.ErrorMessages.Any());
            Assert.IsTrue(result.ErrorMessages.First().ErrorCode == ResponseCode.NotFound.ToString());

        }

        [TestMethod]
        [DynamicData(nameof(ApplyDataForNoResultTestCases))]
        [ExpectedException(typeof(ArgumentException), "passengers numbers")]
        public async Task GetListingAsync_WhenListingNotNull_NoResult_ReturnArgumentExeption(int passenger, string? name)
        {
            //Arrange
            BookingApiAgent.ConfigureGetListingByPassengersAsyncToReturn(JournyFixtures.Default);

            //Act
            await BookingService.GetListingAsync(passenger, name);
        }

        [TestMethod]
        [DynamicData(nameof(ApplyDataForPassengersNoNameTestCases))]
        public async Task GetListingAsync_WhenListingNotNull_ResultForPassengers_NOT_Name_ReturnResult(int passenger, string? name)
        {
            //Arrange
            BookingApiAgent.ConfigureGetListingByPassengersAsyncToReturn(JournyFixtures.Default);

            //Act
            var result = await BookingService.GetListingAsync(passenger, name);

            //Accert
            Assert.IsTrue(result.Data.Result.Count > 0);
        }

        [TestMethod]
        [DynamicData(nameof(ApplyDataForPassengersAndNameTestCases))]
        public async Task GetListingAsync_WhenListingNotNull_ResultForPassengers_AND_Name_ReturnResult(int passenger, string? name)
        {
            //Arrange
            BookingApiAgent.ConfigureGetListingByPassengersAsyncToReturn(JournyFixtures.Default);

            //Act
            var result = await BookingService.GetListingAsync(passenger, name);

            //Accert
            Assert.IsTrue(result.Data.Result.Count > 0);
        }

        [TestMethod]
        [DynamicData(nameof(ApplyDataForThreePassengersAndNameSedanTestCases))]
        public async Task GetListingAsync_WhenListingNotNull_ResultFor_ThreePassengers_AND_SedanName_ReturnResult(int passenger, string? name)
        {
            //Arrange
            BookingApiAgent.ConfigureGetListingByPassengersAsyncToReturn(JournyFixtures.Default);

            //Act
            var result = await BookingService.GetListingAsync(passenger, name);

            //Accert 
            // 100  20
            result.Data.Result.ForEach(x =>
                Assert.IsTrue(x.Name == "ListingVIPThree" || x.Name == "ListingThree"));
        }

        private static IEnumerable<object[]> ApplyDataForNullTestCases
        {
            get
            {
                return new[]
                {
                    new object[] { 1, "Benz" },
                    new object[] { 15, null   }
                };
            }
        }

        private static IEnumerable<object[]> ApplyDataForNoResultTestCases
        {
            get
            {
                return new[]
                {
                    new object[] { 30, "Benz" },
                    new object[] { 2, "suv" }
                };
            }
        }

        private static IEnumerable<object[]> ApplyDataForPassengersNoNameTestCases
        {
            get
            {
                return new[]
                {
                    new object[] { 3, null },
                    new object[] { 2, null },
                    new object[] { 5, null }
                };
            }
        }

        private static IEnumerable<object[]> ApplyDataForPassengersAndNameTestCases
        {
            get
            {
                return new[]
                {
                    new object[] { 3, "sedan" },
                    new object[] { 2, "hatchBack" },
                    new object[] { 5, "suv" }
                };
            }
        }

        private static IEnumerable<object[]> ApplyDataForThreePassengersAndNameSedanTestCases
        {
            get
            {
                return new[]
                {
                    new object[] { 3, "sedan" }
                };
            }
        }
    }
}
