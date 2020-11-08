using ObceImport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace ObceImport.Mappers
{
    class MunicipalityMapper : CsvMapping<MunicipalityPopulation>
    {
        public MunicipalityMapper() : base()
        {
            MapProperty(0, x => x.LAU1);
            MapProperty(1, x => x.LAU2);
            MapProperty(2, x => x.Name);
            MapProperty(3, x => x.Total);
            MapProperty(4, x => x.Men);
            MapProperty(5, x => x.Women);
            MapProperty(6, x => x.Age);
            MapProperty(7, x => x.MensAge);
            MapProperty(8, x => x.WomensAge);
        }
    }
}
