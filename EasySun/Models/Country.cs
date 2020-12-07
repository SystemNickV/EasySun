using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasySun.Models
{
    /// <summary>
    /// Represents Country model.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Database unique key of the country record.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// Display name of the country.
        /// </summary>
        [Required]
        [Column(TypeName = "nchar(64)")]
        [StringLength(64, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Cities located in the country.
        /// </summary>
        public List<City> Cities { get; set; }
    }
}
