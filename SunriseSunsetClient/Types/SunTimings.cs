using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SunriseSunsetClient.Types
{
    /// <summary>
    /// Represents data containing sun timings.
    /// </summary>
    public class SunTimings
    {
        /// <summary>
        /// Sunrise time (UTC).
        /// </summary>
        [JsonProperty("sunrise")]
        public DateTime SunriseAtUtc { get; set; }

        /// <summary>
        /// Sunset time (UTC).
        /// </summary>
        [JsonProperty("sunset")]
        public DateTime SunsetAtUtc { get; set; }

        /// <summary>
        /// Solar noon time (UTC).
        /// </summary>
        [JsonProperty("solar_noon")]
        public DateTime SolarNoonAtUtc { get; set; }

        /// <summary>
        /// Astronomical twilight start time (UTC).
        /// </summary>
        [JsonProperty("astronomical_twilight_begin")]
        public DateTime AstronomicalTwilightStartsAtUtc { get; set; }

        /// <summary>
        /// Astronomical twilight end time (UTC).
        /// </summary>
        [JsonProperty("astronomical_twilight_end")]
        public DateTime AstronomicalTwilightEndsAtUtc { get; set; }

        /// <summary>
        /// Civil twilight start time (UTC).
        /// </summary>
        [JsonProperty("civil_twilight_begin")]
        public DateTime CivilTwilightStartsAtUtc { get; set; }

        /// <summary>
        /// Civil twilight end time (UTC).
        /// </summary>
        [JsonProperty("civil_twilight_end")]
        public DateTime CivilTwilightEndsAtUtc { get; set; }

        /// <summary>
        /// Nautical twilight start time (UTC).
        /// </summary>
        [JsonProperty("nautical_twilight_begin")]
        public DateTime NauticalTwilightStartsAtUtc { get; set; }

        /// <summary>
        /// Nautical twilight end time (UTC).
        /// </summary>
        [JsonProperty("nautical_twilight_end")]
        public DateTime NauticalTwilightEndsAtUtc { get; set; }

        /// <summary>
        /// Length of the requested day in seconds.
        /// </summary>
        [JsonProperty("day_length")]
        public int DayLengthInSeconds { get; set; }

        /// <summary>
        /// Length of the requested day in minutes.
        /// </summary>
        public double DayLengthInMinutes => DayLengthInSeconds / 60D;

        /// <summary>
        /// Length of the requested day in hours.
        /// </summary>
        public double DayLengthInHours => DayLengthInMinutes / 60D;


        /// <summary>
        /// Explicitly set <see cref="DateTimeKind">Kind</see> property of all <see cref="DateTime"/> properties in the <see cref="SunTimings"/> received in the response to UTC.
        /// Called once after successful receiving of response.
        /// </summary>
        internal void SetupDatesForUtc()
        {
            var props = GetType().GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType != typeof(DateTime)) 
                    continue;

                var date = (DateTime)prop.GetValue(this, null);
                date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
                prop.SetValue(this, date, null);
            }
        }

        /// <summary>
        /// Changes the time zone for all dates in this <see cref="SunTimings"/> instance.
        /// </summary>
        /// <param name="timeZoneId">The timezone that will apply to all <see cref="DateTime"/> properties.</param>
        public void ChangeTimeZone(string timeZoneId)
        {
            // Check if provided time zone exists in the local system
            var validTimeZone = TimeZoneInfo.GetSystemTimeZones()
                .Any(timeZone => timeZone.Id == timeZoneId);
            if (!validTimeZone)
                throw new ArgumentException("Invalid time zone id", nameof(timeZoneId));

            var props = GetType().GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType != typeof(DateTime))
                    continue;

                var date = (DateTime)prop.GetValue(this, null);
                date = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date, timeZoneId);
                prop.SetValue(this, date, null);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            const string format = "yyyy-MM-dd HH:mm:ss";

            int dayHours = (int)DayLengthInHours;
            int dayMinutes = (int)DayLengthInMinutes - dayHours * 60;
            int daySeconds = DayLengthInSeconds - dayMinutes * 60 - dayHours * 60 * 60; 

            result.AppendLine($"Sunrise: {SunriseAtUtc.ToString(format)}");
            result.AppendLine($"Sunset: {SunsetAtUtc.ToString(format)}");
            result.AppendLine($"Solar noon: {SolarNoonAtUtc.ToString(format)}");
            result.AppendLine($"Day length: {dayHours:D2}:{dayMinutes:D2}:{daySeconds:D2}");
            result.AppendLine($"Civil twilight start: {CivilTwilightStartsAtUtc.ToString(format)}");
            result.AppendLine($"Civil twilight end: {CivilTwilightEndsAtUtc.ToString(format)}");
            result.AppendLine($"Nautical twilight start: {NauticalTwilightStartsAtUtc.ToString(format)}");
            result.AppendLine($"Nautical twilight end: {NauticalTwilightEndsAtUtc.ToString(format)}");
            result.AppendLine($"Astronomical twilight start: {AstronomicalTwilightStartsAtUtc.ToString(format)}");
            result.AppendLine($"Astronomical twilight end: {AstronomicalTwilightEndsAtUtc.ToString(format)}");
            
            return result.ToString();
        }
    }
}
