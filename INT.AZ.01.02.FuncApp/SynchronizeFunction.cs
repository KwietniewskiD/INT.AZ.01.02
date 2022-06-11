using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace INT.AZ._01._02.FuncApp
{
    public class SynchronizeFunction
    {
        private static HttpClient _httpClient;

        [FunctionName("SynchronizeFunction")]
        public static async Task Run([TimerTrigger("0 0 2 * * *")] TimerInfo myTimer, ILogger log)
        {
            var endpointUrl = Environment.GetEnvironmentVariable("SynchronizationEndpoint");
            await _httpClient.PostAsync(endpointUrl, new StringContent("payload"));
        }
    }
}
