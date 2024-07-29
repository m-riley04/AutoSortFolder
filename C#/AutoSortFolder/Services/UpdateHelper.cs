using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AutoSortFolder
{
    public class LatestReleaseResult
    {
        public JsonDocument json { get; set; }
        public string version { get; set; }
        public HttpResponseHeaders headers { get; set; }
        public HttpStatusCode code { get; set; }
        public string errorMessage { get; set; }
    }

    public class UpdateHelper
    {
        string githubURL = "https://github.com/m-riley04/AutoSortFolder";
        string latestReleaseURL = "https://api.github.com/repos/m-riley04/AutoSortFolder/releases/latest";
        string version;

        public UpdateHelper() 
        {
            version = "0.0.0";
        }

        public UpdateHelper(string version)
        {
            this.version = version;
        }

        public bool CheckForUpdate()
        {


            return false;
        }

        public async Task<LatestReleaseResult> GetLatestRelease()
        {
            HttpClient client = new HttpClient();
            LatestReleaseResult result = new LatestReleaseResult();

            try
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");

                HttpResponseMessage response = await client.GetAsync(latestReleaseURL);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JsonDocument json = JsonDocument.Parse(responseBody);

                // Get the version name
                if (json.RootElement.TryGetProperty("tag_name", out JsonElement tagNameElement)) result.version = tagNameElement.GetString();
                else result.version = "null";

                result.json = json;
                result.headers = response.Headers;
                result.code = response.StatusCode;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\nException caught while getting latest release: {e.Message}");
                result.errorMessage = e.Message;
            }
            return result;
        }
    }
}
