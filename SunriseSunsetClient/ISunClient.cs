using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SunriseSunsetClient.Types;

namespace SunriseSunsetClient
{
    /// <summary>
    /// A client interface to use the Sunrise Sunset API.
    /// <see href="https://sunrise-sunset.org/api"/>
    /// </summary>
    public interface ISunClient
    {
        #region Config Properties

        /// <summary>
        /// Timeout for requests.
        /// </summary>
        TimeSpan Timeout { get; set; }

        #endregion

        /// <summary>
        /// Use this method to get the sun timings.
        /// </summary>
        /// <param name="latitude">Latitude in decimal degrees.</param>
        /// <param name="longitude">Longitude in decimal degrees.</param>
        /// <param name="date">Date in YYYY-MM-DD format. Also accepts other date formats and even relative date formats.</param>
        /// <param name="callback">Callback function name for JSONP response.</param>
        /// <param name="formatted">Time values in response will be expressed following ISO 8601 and day length will be expressed in seconds.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>On success, the <see cref="SunTimings"/> for a given latitude and longitude is returned.</returns>
        Task<SunTimings> GetSunTimingsAsync(
            decimal latitude,
            decimal longitude,
            DateTime date = default,
            string callback = default,
            bool formatted = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Use this method to get the sun timings.
        /// </summary>
        /// <param name="locationData"><see cref="LocationData"/> for the requested sun timings.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>On success, the <see cref="SunTimings"/> for a given latitude and longitude is returned.</returns>
        /// <exception cref="HttpRequestException"></exception>
        Task<SunTimings> GetSunTimingsAsync(LocationData locationData, CancellationToken cancellationToken = default);
    }
}
