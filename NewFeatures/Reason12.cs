using BenchmarkDotNet.Attributes;
using Microsoft.IO;
using System.Text.Json;

namespace NewFeatureBenchmarks;

[MemoryDiagnoser, HtmlExporter]
public class Reason12
{
    private RecyclableMemoryStreamManager recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
    private List<Person> people = Enumerable.Range(0, 10_000).Select(i => new Person { Age = i % 80, Name = "Akos" + i.ToString() }).ToList();

    [Benchmark(Baseline = true)]
    public async Task SerializerUsingMemoryStream()
    {
        for (int i = 0; i < 100; i++)
        {
            using (var stream = new MemoryStream())
            {
                await JsonSerializer.SerializeAsync(stream, people);
            }
        }

    }

    [Benchmark]
    public async Task SerializerUsingRecyclableMemoryStream()
    {
        for (int i = 0; i < 100; i++)
        {
            using (var stream = recyclableMemoryStreamManager.GetStream())
            {
                await JsonSerializer.SerializeAsync(stream, people);
            }
        }
    }


    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
