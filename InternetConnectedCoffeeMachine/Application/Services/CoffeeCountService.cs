using Microsoft.Extensions.Caching.Memory;

namespace InternetConnectedCoffeeMachine.Application.Services
{
    public class CoffeeCountService : ICoffeeCountService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _coffeeCallCacheKey = Constants.CoffeeCallCache.CoffeeCallCacheKey;
        private readonly int _coffeeCallMax = Constants.CoffeeCallCache.CoffeeCallMax;
        private readonly int _initilalCatche = Constants.CoffeeCallCache.InitilalCatche;
        private readonly int _expireDuration = Constants.CoffeeCallCache.ExpireDurationMinutes;

        public CoffeeCountService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public int GetCoffeeCallCount()
        {

            var count = _memoryCache.Get<int>(_coffeeCallCacheKey);

            if (count >= _coffeeCallMax)
            {
                _memoryCache.Set(_coffeeCallCacheKey, _initilalCatche, TimeSpan.FromMinutes(30));

                return _initilalCatche;
            }

            count++;
            _memoryCache.Set(_coffeeCallCacheKey, count, TimeSpan.FromMinutes(_expireDuration));

            return count;
        }
    }
}
