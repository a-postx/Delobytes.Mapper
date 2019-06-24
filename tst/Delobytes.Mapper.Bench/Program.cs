using BenchmarkDotNet.Running;

namespace Delobytes.Mapper.Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MapObjectBenchmark>();
            BenchmarkRunner.Run<MapArrayBenchmark>();
            BenchmarkRunner.Run<MapListBenchmark>();
        }
    }
}
