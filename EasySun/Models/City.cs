using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasySun.Models
{
    /// <summary>
    /// Represents City model.
    /// </summary>
    public class City
    {
        private decimal _latitude;
        private decimal _longitude;

        /// <summary>
        /// Database unique key of the city record.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// Display name of the city.
        /// </summary>
        [Required]
        [Column(TypeName = "nchar(88)")]
        [StringLength(88, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Latitude of the city.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(10, 8)")]
        public decimal Latitude
        {
            get => _latitude;
            set
            {
                if (value < -90 || value > 90)
                    throw new ArgumentOutOfRangeException(nameof(value), $"Latitude ranges from -90 to 90, got {value}");
                _latitude = value;
            }
        }

        /// <summary>
        /// Longitude of the city.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(11, 8)")]
        public decimal Longitude
        {
            get => _longitude;
            set
            {
                if (value < -180 || value > 180)
                    throw new ArgumentOutOfRangeException(nameof(value), $"Longitude ranges from -180 to 180, got {value}");
                _longitude = value;
            }
        }

        /// <summary>
        /// Country foreign key.
        /// </summary>
        [Required]
        public long CountryFK { get; set; }

        /// <summary>
        /// Country to which it relates.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Saved sunrise, sunset timings for this city.
        /// </summary>
        public List<EventTime> EventTimings { get; set; }
    }
}
