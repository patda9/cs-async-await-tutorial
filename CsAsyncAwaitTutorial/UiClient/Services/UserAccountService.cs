using System.Net.Http;
using System.Threading.Tasks;

namespace UiClient.Services
{
    public class UserAccountService
    {
        private readonly HttpClient _httpClient = new();

        public string GetUsers()
        {
            var resultTask = _httpClient.GetStringAsync("http://localhost:5665/UserAccounts");

            return resultTask.Result;
        }

        public async Task<string> GetUsersAsync()
        {
            var resultTask = _httpClient.GetStringAsync("http://localhost:5665/UserAccounts");

            return await resultTask;
        }
    }
}