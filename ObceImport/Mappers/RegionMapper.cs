using ObceImport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace ObceImport.Mappers
{
    class RegionMapper : CsvMapping<Region>
    {
        public RegionMapper() : base()
        {
            MapProperty(0, x => x.NUTS3);
            MapProperty(1, x => x.Name);
        }
    }
}
