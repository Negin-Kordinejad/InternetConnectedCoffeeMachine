namespace RideBooking.Service.Test.Fixtures
{
    internal static class VehicleTypeFixture
    {
        internal static Vehicletype Default = new Fixture().Build<Vehicletype>()
                    .With(x => x.name, "default")
                    .With(x => x.maxPassengers, 1)
                    .Create();

        internal static Vehicletype Hatchback_TWO = new Fixture().Build<Vehicletype>()
               .With(x => x.name, "hatchback")
               .With(x => x.maxPassengers, 2)
               .Create();

        internal static Vehicletype Sedan_THREE = new Fixture().Build<Vehicletype>()
                  .With(x => x.name, "sedan")
                  .With(x => x.maxPassengers, 3)
                  .Create();

        internal static Vehicletype SUV_FIVE= new Fixture().Build<Vehicletype>()
                .With(x => x.name, "suv")
                .With(x => x.maxPassengers, 5)
                .Create();
    }
}
