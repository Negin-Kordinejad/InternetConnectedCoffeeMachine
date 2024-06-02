using Moq;

namespace InternetConnectedCoffeeMachine.Facts
{
    public class FunctionalTestBase
    {
        protected readonly Mock<ILogger<LocationService>> LocationLogger = new Mock<ILogger<LocationService>>();
        protected readonly Mock<IBookingApiAgent> BookingApiAgent = new Mock<IBookingApiAgent>();
        protected readonly Mock<ILocationApiAgent> LocationApiAgent = new Mock<ILocationApiAgent>();
        protected BookingService BookingService;
        protected LocationService LocationService;



        [TestInitialize]
        public void Initialize()
        {
            BookingService = new BookingService(BookingLogger.Object, BookingApiAgent.Object);
            LocationService = new LocationService(LocationLogger.Object, LocationApiAgent.Object);
        }
    }
}