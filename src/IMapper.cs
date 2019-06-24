namespace Delobytes.Mapper
{
    /// <summary>
    /// Maps an object of type <typeparamref name="TSource"/> to <typeparamref name="TDestination"/>.
    /// </summary>
    /// <typeparam name="TSource">Object type to map from.</typeparam>
    /// <typeparam name="TDestination">Object type to map to.</typeparam>
    public interface IMapper<in TSource, in TDestination>
    {
        /// <summary>
        /// Maps a specified source object into destination object.
        /// </summary>
        /// <param name="source">Source object to map from.</param>
        /// <param name="destination">Destination object to map to.</param>
        void Map(TSource source, TDestination destination);
    }
}
