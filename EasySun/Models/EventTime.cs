using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasySun.Models
{
    /// <summary>
    /// Represents EventTime model.
    /// </summary>
    public class EventTime
    {
        /// <summary>
        /// Database unique key of the event time record.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// Date of requested sun info.
        /// </summary>
        /// [Required]
        [Column(TypeName = "datetime")]
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Sunrise time.
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Sunrise { get; set; }

        /// <summary>
        /// Sunset time.
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Sunset { get; set; }

        /// <summary>
        /// City foreign key.
        /// </summary>
        [Required]
        public long CityFK { get; set; }

        /// <summary>
        /// City to which this timings relate.
        /// </summary>
        public City City { get; set; }
    }
}
