 // ReSharper disable once CheckNamespace - Extension method
namespace System
{
    using AutoMapper;

    public static class ObjectExtensions
    {
        public static TDestination Map<TDestination>(this object @this)
        {
            return Mapper.Map<TDestination>(@this);
        }
    }
}