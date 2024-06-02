namespace RideBooking.Service.Test.Fixtures
{
    internal static class ListingFixtures
    {
        internal static Listing ListingVIPForTwo = new Fixture().Build<Listing>()
        .With(x => x.name, "ListingVIPTwo")
        .With(x => x.pricePerPassenger, 100)
        .With(x => x.vehicleType, () => VehicleTypeFixture.Hatchback_TWO)
        .Create();

        internal static Listing ListingVIPForThree = new Fixture().Build<Listing>()
        .With(x => x.name, "ListingVIPThree")
        .With(x => x.pricePerPassenger, 100)
        .With(x => x.vehicleType, () => VehicleTypeFixture.Sedan_THREE)
        .Create();

        internal static Listing ListingVIPForFive = new Fixture().Build<Listing>()
        .With(x => x.name, "ListingVIPFive")
        .With(x => x.pricePerPassenger, 100)
        .With(x => x.vehicleType, () => VehicleTypeFixture.SUV_FIVE)
        .Create();

        internal static Listing ListingForTwo = new Fixture().Build<Listing>()
        .With(x => x.name, "ListingTwo")
        .With(x => x.pricePerPassenger, 20)
        .With(x => x.vehicleType, () => VehicleTypeFixture.Hatchback_TWO)
        .Create();

        internal static Listing ListingForThree = new Fixture().Build<Listing>()
        .With(x => x.name, "ListingThree")
        .With(x => x.pricePerPassenger, 20)
        .With(x => x.vehicleType, () => VehicleTypeFixture.Sedan_THREE)
        .Create();

        internal static Listing ListingForFive = new Fixture().Build<Listing>()
        .With(x => x.name, "ListingFive")
        .With(x => x.pricePerPassenger, 20)
        .With(x => x.vehicleType, () => VehicleTypeFixture.SUV_FIVE)
        .Create();

        internal static List<Listing> totalListing = new()
        { ListingVIPForTwo, ListingVIPForThree, ListingVIPForFive, ListingForTwo, ListingForThree , ListingForFive};


    }
}
