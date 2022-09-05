using System;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Delobytes.Mapper.Bench.Mapping;
using Delobytes.Mapper.Bench.Models;

namespace Delobytes.Mapper.Bench
{
    [KeepBenchmarkFiles]
    [SimpleJob(RuntimeMoniker.Net60)]
    [MinColumn]
    [MaxColumn]
    [HtmlExporter]
    [CsvMeasurementsExporter]
    [RPlotExporter]
    [MemoryDiagnoser]
    public class MapArrayBenchmark
    {
        private readonly IMapper _automapper;
        private readonly IMapper<MapFrom, MapTo> _boilerplateMapper;
        private readonly Random _random;
        private MapFrom[] _mapFrom;

        public MapArrayBenchmark()
        {
            _automapper = AutomapperConfiguration.CreateMapper();
            _boilerplateMapper = new DelobytesMapper();
            _random = new Random();
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _mapFrom = new MapFrom[100];

            for (var i = 0; i < _mapFrom.Length; ++i)
            {
                _mapFrom[i] = new MapFrom()
                {
                    BooleanFrom = _random.NextDouble() > 0.5D,
                    DateTimeOffsetFrom = DateTimeOffset.UtcNow,
                    IntegerFrom = _random.Next(),
                    LongFrom = _random.Next(),
                    StringFrom = _random.Next().ToString()
                };
            }
        }

        [Benchmark(Baseline = true)]
        public MapTo[] Baseline()
        {
            var destination = new MapTo[_mapFrom.Length];

            for (var i = 0; i < _mapFrom.Length; ++i)
            {
                var item = _mapFrom[i];
                destination[i] = new MapTo()
                {
                    BooleanTo = item.BooleanFrom,
                    DateTimeOffsetTo = item.DateTimeOffsetFrom,
                    IntegerTo = item.IntegerFrom,
                    LongTo = item.LongFrom,
                    StringTo = item.StringFrom
                };
            }

            return destination;
        }

        [Benchmark]
        public MapTo[] DelobytesMapper() => _boilerplateMapper.MapArray(_mapFrom);

        [Benchmark]
        public MapTo[] Automapper() => _automapper.Map<MapTo[]>(_mapFrom);
    }
}
