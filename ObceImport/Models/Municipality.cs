using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ObceImport.Models
{
    class Municipality
    {
        [Key]
        [MaxLength(6)]
        public string LAU2 { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("LAU1")]
        public District District { get; set; }
        [Required]
        public string LAU1 { get; set; }
        public ICollection<Population> PopulationData { get; set; }
    }
}
