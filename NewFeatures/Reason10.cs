using BenchmarkDotNet.Attributes;
using System.Text;
using System.Text.Json;

namespace NewFeatureBenchmarks;

[MemoryDiagnoser, HtmlExporter]
public class Reason10
{
    private string webrequestBody;
    private const string path="webRequestBody.json";

    [GlobalSetup]
    public void ReadContent()
    {
        webrequestBody = File.ReadAllText(path);
    }

    [Benchmark(Baseline = true)]
    public bool RegularStringbenchmark()
    {
        using JsonDocument doc = JsonDocument.Parse(webrequestBody);
        var property = doc.RootElement.GetProperty("propertyLast");
        if (property.GetString() == "last")
        {
            return true;
        }
        return false;
    }


    private byte[] propertyName = Encoding.UTF8.GetBytes("propertyLast");
    private byte[] propertyValue = Encoding.UTF8.GetBytes("last");

    [Benchmark]
    public bool EncodedStringbenchmark()
    {
        using JsonDocument doc = JsonDocument.Parse(webrequestBody);
        var property = doc.RootElement.GetProperty(propertyName);
        if (property.ValueEquals(propertyValue))
        {
            return true;
        }
        return false;
    }


    [Benchmark]
    public bool NativeUtf8Stringbenchmark()
    {
        using JsonDocument doc = JsonDocument.Parse(webrequestBody);
        var property = doc.RootElement.GetProperty("propertyLast"u8);
        if (property.ValueEquals("last"u8))
        {
            return true;
        }
        return false;
    }
}
