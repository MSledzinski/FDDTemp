namespace NotesWebApp.Infrastructure
{
    public class CacheItem<T>
    {
        public CacheItem(bool hasValue, T value)
        {
            HasValue = hasValue;
            Value = value;
        }

        public bool HasValue { get; }

        public T Value { get; }

        public static CacheItem<T> WithValue(T value)
        {
            return new CacheItem<T>(true, value);
        }

        public static CacheItem<T> Empty()
        {
            return new CacheItem<T>(false, default(T));
        }
    }
}