using BenchmarkDotNet.Running;
using NewFeatureBenchmarks;

BenchmarkRunner.Run(new[] {typeof(Reason10), typeof(Reason11), typeof(Reason12)});