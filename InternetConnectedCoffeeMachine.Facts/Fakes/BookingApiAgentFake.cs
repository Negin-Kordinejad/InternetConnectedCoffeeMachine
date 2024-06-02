namespace RideBooking.Service.Test.Fakes
{
    internal static class BookingApiAgentFake
    {
        internal static Mock<IBookingApiAgent> ConfigureGetListingByPassengersAsyncToReturn(
            this Mock<IBookingApiAgent> instance, Journy response)
        {
            instance.Setup(x => x.GetListingByPassengersAsync())
                .ReturnsAsync(() => response);

            return instance;
        }
    }
}
