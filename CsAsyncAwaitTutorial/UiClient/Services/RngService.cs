using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UiClient.Services
{
    public class RngService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<string> GetRandomIntegerString()
        {
            return await _httpClient.GetStringAsync("https://localhost:44340/Rng/HundredThousand");
        }

        public async Task<int> GetRandomInteger()
        {
            return await Task.Run(() => int.Parse(GetRandomIntegerString().Result));
        }

        public int[] GetRandomIntegersSync()
        {
            var count = new Random().Next(1, 5);
            var integers = new int[count];

            for (var i = 0; i < count; i++)
            {
                integers[i] = Task.Run(() => GetRandomInteger()).Result;
            }

            return integers;
        }

        public async Task<int[]> GetRandomIntegersAsync()
        {
            var count = new Random().Next(1, 5);
            var integers = new int[count];

            for (var i = 0; i < count; i++)
            {
                integers[i] = await Task.Run(() => GetRandomInteger());
            }

            return integers;
        }

        public async Task<int[]> GetRandomIntegersAsyncParallel()
        {
            var count = new Random().Next(1, 11);
            var tasks = Enumerable.Range(0, count)
                .Select(i => Task.Run(() => GetRandomInteger()));

            return await Task.WhenAll(tasks);
        }
    }
}