using System.Threading.Tasks;

namespace Delobytes.Mapper
{
    /// <summary>
    /// Maps an object of type <typeparamref name="TSource"/> to <typeparamref name="TDestination"/> asynchronously.
    /// </summary>
    /// <typeparam name="TSource">Object type to map from.</typeparam>
    /// <typeparam name="TDestination">Object type to map to.</typeparam>
    public interface IAsyncMapper<in TSource, in TDestination>
    {
        /// <summary>
        /// Maps the specified source object into destination object.
        /// </summary>
        /// <param name="source">Source object to map from.</param>
        /// <param name="destination">Destination object to map to.</param>
        /// <returns>A task representing the operation.</returns>
        Task MapAsync(TSource source, TDestination destination);
    }
}
