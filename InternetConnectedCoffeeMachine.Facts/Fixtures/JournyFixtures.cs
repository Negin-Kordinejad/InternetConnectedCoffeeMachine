namespace RideBooking.Service.Test.Fixtures
{
    internal static class JournyFixtures
    {
        internal static Journy Default = new Fixture().Build<Journy>()
            .With(x => x.from, "Address1")
            .With(x => x.to, "Address2")
            .With(x => x.listings, () => ListingFixtures.totalListing.ToArray())
            .Create();
    }
}
