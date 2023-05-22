public class Reason01
{
    public List<string> ReadAllLinesV1()
    {
        var lines = new List<string>();
        using var streamReader = new StreamReader("input.txt");
        while (!streamReader.EndOfStream)
        {
            lines.Add(streamReader.ReadLine());
        }
        return lines;
    }


    public IEnumerable<string> ReadAllLinesV2()
    {
        var lines = new List<string>();
        using var streamReader = new StreamReader("input.txt");
        while (!streamReader.EndOfStream)
        {
            yield return streamReader.ReadLine();
        }
    }

    public IEnumerable<Task<string>> ReadAllLinesV3()
    {
        using var streamReader = new StreamReader("input.txt");
        while (!streamReader.EndOfStream)
        {
            yield return streamReader.ReadLineAsync();
        }
    }

    public async Task<IEnumerable<string>> ReadAllLinesV4()
    {
        List<string> lines = new List<string>();
        using var streamReader = new StreamReader("input.txt");
        while (!streamReader.EndOfStream)
        {
            lines.Add(await streamReader.ReadLineAsync());
        }
        return lines;
    }

    public async IAsyncEnumerable<string> ReadAllLinesV5()
    {
        List<string> lines = new List<string>();
        using var streamReader = new StreamReader("input.txt");
        while (!streamReader.EndOfStream)
        {
            yield return await streamReader.ReadToEndAsync();
        }
    }
}