using Delobytes.Mapper.Bench.Models;

namespace Delobytes.Mapper.Bench.Mapping
{
    public class DelobytesMapper : IMapper<MapFrom, MapTo>
    {
        public void Map(MapFrom source, MapTo destination)
        {
            destination.BooleanTo = source.BooleanFrom;
            destination.DateTimeOffsetTo = source.DateTimeOffsetFrom;
            destination.IntegerTo = source.IntegerFrom;
            destination.LongTo = source.LongFrom;
            destination.StringTo = source.StringFrom;
        }
    }
}
