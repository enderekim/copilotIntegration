using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to My Console App!");

            // GitHub API URL
            string apiUrl = "https://api.github.com/orgs/Dogus-Teknoloji/copilot/metrics";

            // GitHub Personal Access Token (replace with environment variable for security)
            string token = "";

            using (HttpClient client = new HttpClient())
            {
                // Add headers
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
                client.DefaultRequestHeaders.Add("User-Agent", "MyConsoleApp");

                try
                {
                    // Make the GET request
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    // Read and display the response
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API Response:");
                    Console.WriteLine(responseBody);
                }
                catch (Exception ex)é
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}