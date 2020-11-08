using System;
using System.Collections.Generic;
using System.Text;

namespace ObceImport.Models
{
    class MunicipalityPopulation
    {
        public string LAU2 { get; set; }
        public string Name { get; set; }
        public District District { get; set; }
        public string LAU1 { get; set; }
        public int Total { get; set; }
        public int Men { get; set; }
        public int Women { get; set; }
        public string Age { get; set; }
        public string MensAge { get; set; }
        public string WomensAge { get; set; }
    }
}
