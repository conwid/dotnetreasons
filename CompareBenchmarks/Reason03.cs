using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;

namespace CompareBenchmarks
{
    public class Reason03
    {
        [Benchmark]
        public Node CreateNode() => Activator.CreateInstance<Node>();

        public class Node { }
    }
}