using ObceImport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace ObceImport.Mappers
{
    class DistrictMapper : CsvMapping<District>
    {
        public DistrictMapper() : base()
        {
            MapProperty(0, x => x.LAU1);
            MapProperty(1, x => x.Name);
            MapProperty(2, x => x.NUTS3);
        }
    }
}
