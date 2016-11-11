namespace NotesWebApp.Infrastructure
{
    using System;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using StackExchange.Redis;

    public static class CacheProvider
    {
        private static readonly IDatabase Database;

        static CacheProvider()
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect(Configuration.RedisConnectionString);
            connectionMultiplexer.PreserveAsyncOrder = false;

            Database = connectionMultiplexer.GetDatabase(0);
        }

        public static async Task<bool> Insert<T>(string key, T value, int expiry)
        {
            var serialized = JsonConvert.SerializeObject(value);
            return await Database.StringSetAsync(key, serialized, TimeSpan.FromMinutes(expiry));
        }

        public static async Task<CacheItem<T>> Get<T>(string key)
        {
            var serializedObject = await Database.StringGetAsync(key);
            return AsCacheResult<T>(serializedObject);
        }

        private static CacheItem<T> AsCacheResult<T>(RedisValue serializedObject)
        {
            return new CacheItem<T>(
                serializedObject.HasValue,
                !serializedObject.HasValue ? default(T) : JsonConvert.DeserializeObject<T>(serializedObject));
        }
    }
}

