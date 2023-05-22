using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using CompareBenchmarks;


class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run(
            new[] { typeof(Reason03),
                    typeof(Reason04),
                    typeof(Reason05),
                    typeof(Reason06),
                    typeof(Reason07),
                    typeof(Reason08),
                    typeof(Reason09)
            },
            new CompareDotnetVersionsConfig());
    }
}



public class CompareDotnetVersionsConfig : ManualConfig
{
    public CompareDotnetVersionsConfig()
    {
        AddJob(Job.Default.WithRuntime(ClrRuntime.Net48)
                          .WithBaseline(true));
        AddJob(Job.Default.WithRuntime(CoreRuntime.Core70));
        AddDiagnoser(MemoryDiagnoser.Default);
        AddLogger(ConsoleLogger.Default);
        AddColumnProvider(DefaultColumnProviders.Instance);
        AddExporter(HtmlExporter.Default);
    }
}