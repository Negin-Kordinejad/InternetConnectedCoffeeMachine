namespace RideBooking.Service.Test.Fakes
{
    internal static class LocationApiAgentFake
    {
        internal static Mock<ILocationApiAgent> ConfigureIpLocatorAsyncToReturn(
           this Mock<ILocationApiAgent> instance, Location response)
        {
            instance.Setup(x => x.IpLocatorAsync(It.IsAny<string>()))
                .Returns(() => response);

            return instance;
        }

    }
}
