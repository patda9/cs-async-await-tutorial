using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WpfClient.Services
{
    public class RngService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<string> GetRandomIntegerString()
        {
            return await _httpClient.GetStringAsync("http://localhost:44340/Rng/HundredThousand");
        }

        public async Task<int> GetRandomInteger()
        {
            return await Task.Run(() => GetRandomIntegerString().ContinueWith(t => int.Parse(t.Result)));
        }

        public async Task<int[]> GetRandomIntegersSeq()
        {
            var count = new Random().Next(1, 11);
            var integers = new int[count];

            for (var i = 0; i < count; i++) integers[i] = await GetRandomInteger();

            return integers;
        }

        public async Task<int[]> GetRandomIntegers()
        {
            var count = new Random().Next(1, 11);
            var tasks = Enumerable.Range(0, count).Select(i => GetRandomInteger());

            return await Task.WhenAll(tasks); ;
        }
    }
}