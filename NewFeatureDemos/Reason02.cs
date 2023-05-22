namespace NewFeatureBenchmarks;


public class NetworkResource : IDisposable
{
    public async void Dispose() // can't be awaited as void; can't change to Task because of the interface
    {
        await SendMessageAsync("CLOSE");
    }

    public async Task SendMessageAsync(string message) { }
    public void SendMessage(string message) { }
}


// usually this is IDisposable in itself
public class AsyncNetworkResource : IAsyncDisposable
{
    public async ValueTask DisposeAsync()
    {
        await SendMessageAsync("CLOSE"); // can be awaited; can be used with await using
    }

    public async Task SendMessageAsync(string message) { }
    public void SendMessage(string message) { }
}


public class Kitchen : IDisposable, IAsyncDisposable
{
    private readonly SemaphoreSlim semaphore = new SemaphoreSlim(3);

    // TODO: Thread-safe data structure
    private readonly List<Task> mealTasks = new List<Task>();
    public void CookMeal(string meal, int duration)
    {
        var t = new Task(() => CookMealInternal(meal, duration))
                    .ContinueWith(r => mealTasks.Remove(r));
        mealTasks.Add(t);
        t.Start();
    }


    private void CookMealInternal(string meal, int duration)
    {
        Console.WriteLine($"Preparing ingredients for meal {meal}");
        try
        {
            semaphore.Wait();
            Console.WriteLine($"Chef prepares meal {meal}");
            Thread.Sleep(TimeSpan.FromSeconds(duration));
            Console.WriteLine($"Chef done with meal {meal}");
        }
        finally
        {
            semaphore.Release();
        }
        Console.WriteLine($"Serving meal {meal}");
    }
    public void Dispose()
    {
        // Optional: Cancel tasks
        Task.WaitAll(mealTasks.ToArray());
        semaphore?.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await Task.WhenAll(mealTasks.ToArray());
        semaphore?.Dispose();
    }
}
