using Polly;
using Polly.Retry;
using System;
using System.Net.Http;

namespace eBar.API.Extensions
{
    public static class PoliciesExtensions
    {
        public const int maxRetryAttempts = 3;
        public static RetryPolicy RetryPolicy() => Policy.Handle<HttpRequestException>().WaitAndRetry(maxRetryAttempts, i => TimeSpan.FromSeconds(2));        
    }
}