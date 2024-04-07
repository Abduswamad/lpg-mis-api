using iText.Html2pdf;
using iText.Kernel.Pdf;
using System.Net;
using System.Net.Mail;
using System.Runtime.Caching;
using System.Text;



public static class Program
{
    private static readonly ObjectCache _cache = MemoryCache.Default;

    public static string GetData(int id)
    {
        string cacheKey = $"Data_{id}";

        // Check if data is already cached
        if (_cache.Contains(cacheKey))
        {
            Console.WriteLine($"Data for ID {id} found in cache.");
            return _cache.Get(cacheKey) as string;
        }
        else
        {
            Console.WriteLine($"Data for ID {id} not found in cache. Fetching from source.");
            // Fetch data from the source (e.g., database, external service)
            string data = FetchDataFromSource(id);

            // Cache the data with a specific expiration time (e.g., 1 hour)
            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
            };
            _cache.Set(cacheKey, data, policy);

            return data;
        }
    }

    private static string FetchDataFromSource(int id)
    {
        // Simulate fetching data from a source (e.g., database, external service)
        return $"Data for ID {id}";
    }
    public static void Main(string[] args)
    {
        hapa:

        var data = GetData(1);
        Console.WriteLine(data);

        goto hapa;
        Console.ReadKey();
    }
}
