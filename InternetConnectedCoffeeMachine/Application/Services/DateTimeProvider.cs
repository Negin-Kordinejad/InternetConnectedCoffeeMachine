﻿namespace InternetConnectedCoffeeMachine.Application.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
