using InternetConnectedCoffeeMachine.Application.Services;
using Moq;

namespace InternetConnectedCoffeeMachine.Integration.Fakes
{
    internal static class DateTimeProviderFake
    {
        internal static Mock<IDateTimeProvider> ConfigureGetCurrentDateTime(
            this Mock<IDateTimeProvider> instance, DateTime response)
        {
            instance.Setup(x => x.Now)
                .Returns(() => response);

            return instance;
        }
    }
}
