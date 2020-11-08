using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ObceImport.Models
{
    class District
    {
        [Key]
        [MaxLength(6)]
        public string LAU1 { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("NUTS3")]
        public Region Region { get; set; }
        [Required]
        public string NUTS3 { get; set; }
        public ICollection<Municipality> Municipalities { get; set; }
    }
}
