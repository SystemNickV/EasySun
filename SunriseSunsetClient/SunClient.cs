using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SunriseSunsetClient.Exceptions;
using SunriseSunsetClient.Types;

namespace SunriseSunsetClient
{
    /// <summary>
    /// A client to use the Sunrise Sunset API.
    /// <see href="https://sunrise-sunset.org/api"/>
    /// </summary>
    public class SunClient : ISunClient
    {
        private const string BaseAddress = "https://api.sunrise-sunset.org/";

        private readonly HttpClient _httpClient;

        #region Config Properties

        /// <inheritdoc />
        public TimeSpan Timeout
        {
            get => _httpClient.Timeout;
            set => _httpClient.Timeout = value;
        }

        /// <summary>
        /// Configurable settings for the deserializer.
        /// </summary>
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };

        #endregion Config Properties

        /// <summary>
        /// Create a new <see cref="SunClient"/> instance.
        /// </summary>
        /// <param name="httpClient">A custom <see cref="HttpClient"/>.</param>
        public SunClient(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        /// <summary>
        /// Create a new <see cref="SunClient"/> instance behind a proxy.
        /// </summary>
        /// <param name="webProxy">Use this <see cref="IWebProxy"/> to connect to the API.</param>
        public SunClient(IWebProxy webProxy)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = webProxy,
                UseProxy = true
            };
            _httpClient = new HttpClient(httpClientHandler);
        }

        /// <inheritdoc/>
        public async Task<SunTimings> GetSunTimingsAsync(
            decimal latitude,
            decimal longitude,
            DateTime date = default,
            string callback = default,
            bool formatted = default,
            CancellationToken cancellationToken = default)
        {
            return await GetSunTimingsAsync(new LocationData 
                {
                    Latitude = latitude,
                    Longitude = longitude,
                    Date = date,
                    Callback = callback,
                    Formatted = formatted
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<SunTimings> GetSunTimingsAsync(LocationData locationData, CancellationToken cancellationToken = default)
        {
            var requestString = $"{BaseAddress}json?{locationData}"; // Raw text for GET request

            HttpResponseMessage httpResponse;

            try
            {
                httpResponse = await _httpClient
                    .GetAsync(requestString, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (TaskCanceledException e)
            {
                if (cancellationToken.IsCancellationRequested)
                    throw;
                throw new ApiRequestException("Request timed out", 408, e);
            }

            var actualResponseStatusCode = httpResponse.StatusCode;
            var responseJson = await httpResponse.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            switch (actualResponseStatusCode)
            {
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.BadRequest when !string.IsNullOrWhiteSpace(responseJson):
                    // Do NOT throw here, the response status will be checked and an ApiRequestException will be thrown later
                    break;
                default:
                    httpResponse.EnsureSuccessStatusCode();
                    break;
            }
            
            var apiResponse = 
                JsonConvert.DeserializeObject<Response>(responseJson ?? string.Empty) 
                ?? new Response
                {
                    Status = "No response received"
                };

            if (!apiResponse.Ok)
                throw ApiExceptionParser.Parse(apiResponse);

            apiResponse.Results.SetupDatesForUtc();

            return apiResponse.Results;
        }
    }
}
