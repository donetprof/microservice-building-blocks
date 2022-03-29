﻿using Polly;
using Polly.Extensions.Http;

namespace ConferenceRegistrationAPI;

public static class HttpPolicies
{
    public static IAsyncPolicy<HttpResponseMessage> GetMarkupRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }
}
