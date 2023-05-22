using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace CompareBenchmarks
{
    public class Reason04
    {

        private MethodInfo m = typeof(Node).GetMethod("DoSomething");
        [Benchmark]
        public ObsoleteAttribute GetCustomAttributes() => m.GetCustomAttribute<ObsoleteAttribute>();

        public class Node
        {
            [Obsolete]
            public bool DoSomething() { return false; }
        }
    }
}