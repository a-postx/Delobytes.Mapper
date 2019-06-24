using System.Threading.Tasks;

namespace Delobytes.Mapper.Test
{
    public class AsyncMapper : IAsyncMapper<MapFrom, MapTo>
    {
        public Task Map(MapFrom from, MapTo to)
        {
            to.Property = from.Property;
            return Task.FromResult<object>(null);
        }
    }
}
