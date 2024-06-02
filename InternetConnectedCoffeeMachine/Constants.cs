namespace InternetConnectedCoffeeMachine
{
    public static class Constants
    {
        public static class Message
        {

            public const string CoffeeReadyMessage = $"Your piping hot coffee is ready";
            public const string IcedCoffeeMessage = $"Your refreshing iced coffee is ready";
        }

        public static class Format
        {
            public const string ISO8601Format = "yyyy-MM-ddTHH:mm:sszzz";
        }

        public static class Dates
        {
            public static class NotWorkingDate
            {
                public const int Month = 4;
                public const int Day = 1;

            }
        }

        public static class CoffeeCallCache
        {
            public const string CoffeeCallCacheKey = "coffee-call-count";
            public const int CoffeeCallMax = 5;
            public const int InitilalCatche = 0; 
            public const int ExpireDurationMinutes = 30;
        }
    }
}
