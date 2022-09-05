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
    public class MapObjectBenchmark
    {
        private readonly IMapper _automapper;
        private readonly IMapper<MapFrom, MapTo> _boilerplateMapper;
        private readonly Random _random;
        private MapFrom _mapFrom;

        public MapObjectBenchmark()
        {
            _automapper = AutomapperConfiguration.CreateMapper();
            _boilerplateMapper = new DelobytesMapper();
            _random = new Random();
        }

        [GlobalSetup]
        public void GlobalSetup() =>
            _mapFrom = new MapFrom()
            {
                BooleanFrom = _random.NextDouble() > 0.5D,
                DateTimeOffsetFrom = DateTimeOffset.UtcNow,
                IntegerFrom = _random.Next(),
                LongFrom = _random.Next(),
                StringFrom = _random.Next().ToString()
            };

        [Benchmark(Baseline = true)]
        public MapTo Baseline() => new MapTo()
        {
            BooleanTo = _mapFrom.BooleanFrom,
            DateTimeOffsetTo = _mapFrom.DateTimeOffsetFrom,
            IntegerTo = _mapFrom.IntegerFrom,
            LongTo = _mapFrom.LongFrom,
            StringTo = _mapFrom.StringFrom
        };

        [Benchmark]
        public MapTo DelobytesMapper() => _boilerplateMapper.Map(_mapFrom);

        [Benchmark]
        public MapTo Automapper() => _automapper.Map<MapTo>(_mapFrom);
    }
}
