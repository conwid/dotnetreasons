// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class GenericDemo<T> where T:new()
{
    public void M()
    {
        T local = new T();
    }
}
