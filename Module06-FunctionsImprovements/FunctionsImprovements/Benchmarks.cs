using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace FunctionsImprovements
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        Collection<int> collection;

        [GlobalSetup]
        public void GlobalSetup()
        {
            collection = new Collection<int>(Enumerable.Range(1, 1000).ToArray());
        }

        [Benchmark(Baseline = true, OperationsPerInvoke = 4)]
        [ArgumentsSource(nameof(Values))]
        public int NonStatic_WithClosure(int value)
        {
            return collection.Find(i => i % value == 0) +
                   collection.Find(i => i % value == 0) +
                   collection.Find(i => i % value == 0) +
                   collection.Find(i => i % value == 0);

        }

        [Benchmark(OperationsPerInvoke = 4)]
        [ArgumentsSource(nameof(Values))]
        public int Static_WithoutClosure0(int value)
        {
            // TODO: change the code below, so that the static lambda is used.
            // Notice that there's an overload for Find that allows passing the state.
            // Watch benchmarks for memory allocations.
            return collection.Find(i => i % value == 0) +
                   collection.Find(i => i % value == 0) +
                   collection.Find(i => i % value == 0) +
                   collection.Find(i => i % value == 0);
        }

        [Benchmark(OperationsPerInvoke = 4)]
        [ArgumentsSource(nameof(Values))]
        public int Static_WithoutClosure1(int value)
        {
            bool IsMatch(int number)
            {
                return number % value == 0;
            }

            return collection.Find(IsMatch) +
                   collection.Find(IsMatch) +
                   collection.Find(IsMatch) +
                   collection.Find(IsMatch);
        }


        [Benchmark(OperationsPerInvoke = 4)]
        [ArgumentsSource(nameof(Values))]
        public int Static_WithoutClosure2(int value)
        {
            static bool IsMatch(int value, int number)
            {
                return number % value == 0;
            }

            return collection.Find<int>(value, IsMatch) +
                   collection.Find<int>(value, IsMatch) +
                   collection.Find<int>(value, IsMatch) +
                   collection.Find<int>(value, IsMatch);
        }

        public IEnumerable<int> Values()
        {
            yield return 513;
        }
    }
}