using System;
using System.Collections.Generic;
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
    public class MapListBenchmark
    {
        private readonly IMapper _automapper;
        private readonly IMapper<MapFrom, MapTo> _boilerplateMapper;
        private readonly Random _random;
        private List<MapFrom> _mapFrom;

        public MapListBenchmark()
        {
            _automapper = AutomapperConfiguration.CreateMapper();
            _boilerplateMapper = new DelobytesMapper();
            _random = new Random();
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _mapFrom = new List<MapFrom>();

            for (var i = 0; i < 100; ++i)
            {
                _mapFrom.Add(
                    new MapFrom()
                    {
                        BooleanFrom = _random.NextDouble() > 0.5D,
                        DateTimeOffsetFrom = DateTimeOffset.UtcNow,
                        IntegerFrom = _random.Next(),
                        LongFrom = _random.Next(),
                        StringFrom = _random.Next().ToString()
                    });
            }
        }

        [Benchmark(Baseline = true)]
        public List<MapTo> Baseline()
        {
            var destination = new List<MapTo>(_mapFrom.Count);

            foreach (var item in _mapFrom)
            {
                destination.Add(new MapTo()
                {
                    BooleanTo = item.BooleanFrom,
                    DateTimeOffsetTo = item.DateTimeOffsetFrom,
                    IntegerTo = item.IntegerFrom,
                    LongTo = item.LongFrom,
                    StringTo = item.StringFrom
                });
            }

            return destination;
        }

        [Benchmark]
        public List<MapTo> DelobytesMapper() => _boilerplateMapper.MapList(_mapFrom);

        [Benchmark]
        public List<MapTo> Automapper() => _automapper.Map<List<MapTo>>(_mapFrom);
    }
}
