using System;
using System.Collections.Generic;

namespace SunriseSunsetClient.Types
{
    /// <summary>
    /// This object represents parameters for Sunrise Sunset API json GET request.
    /// </summary>
    public class LocationData
    {
        /// <summary>
        /// Latitude in decimal degrees.
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Longitude in decimal degrees.
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Optional. Date in YYYY-MM-DD format.
        /// Also accepts other date formats and even relative date formats.
        /// If not present, date defaults to current date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Optional. Callback function name for JSONP response.
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// Optional. Time values in response will be expressed following ISO 8601 and day length will be expressed in seconds.
        /// Defaults to true.
        /// </summary>
        public bool Formatted { get; set; }

        public override string ToString()
        {
            return string.Join('&', new List<string>
            {
                $"lat={Latitude}",
                $"lng={Longitude}",
                Date != DateTime.MinValue ? $"date={Date:yyy-MM-dd}" : string.Empty,
                !string.IsNullOrWhiteSpace(Callback) ? $"callback={Callback}" : string.Empty,
                !Formatted ? "formatted=0" : string.Empty
            });
        }
    }
}
