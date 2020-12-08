using Newtonsoft.Json;

namespace SunriseSunsetClient.Types
{
    /// <summary>
    /// Response received from Sunrise Sunset API containing status and sun timings data.
    /// </summary>
    internal class Response
    {
        /// <summary>
        /// Gets a value indicating whether the request was successful.
        /// </summary>
        public bool Ok => Status == "OK";

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Requested sun timings.
        /// </summary>
        [JsonProperty("results")]
        public SunTimings Results { get; set; }

        /// <summary>
        /// Status of the received response.
        /// May contain information about why a request was unsuccessful.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
