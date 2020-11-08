using ObceImport.Mappers;
using ObceImport.Models;
using System;
using System.Linq;
using System.Text;
using TinyCsvParser;

namespace ObceImport
{
    class Program
    {
        // Source: https://www.czso.cz/csu/czso/pocet-obyvatel-v-obcich-k-112019

        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            CsvParserOptions csvParserOptions = new CsvParserOptions(false, ';');
            //
            Console.WriteLine("-- Purging all tables --");
            db.Populations.RemoveRange(db.Populations.ToArray());
            db.Municipalities.RemoveRange(db.Municipalities.ToArray());
            db.Districts.RemoveRange(db.Districts.ToArray());
            db.Regions.RemoveRange(db.Regions.ToArray());
            db.SaveChanges();
            //
            Console.WriteLine("-- Setting regions --");
            RegionMapper csvRegionMapper = new RegionMapper();
            CsvParser<Region> csvRegionParser = new CsvParser<Region>(csvParserOptions, csvRegionMapper);
            var regions = csvRegionParser
                .ReadFromFile(@"Files/Regions.csv", Encoding.UTF8)
                .ToList();
            foreach(var item in regions)
            {
                Console.WriteLine(item.Result.Name);
                db.Regions.Add(item.Result);
            }
            db.SaveChanges();
            //
            Console.WriteLine("-- Setting districts --");
            DistrictMapper csvDistrictMapper = new DistrictMapper();
            CsvParser<District> csvDistrictParser = new CsvParser<District>(csvParserOptions, csvDistrictMapper);
            var districts = csvDistrictParser
                .ReadFromFile(@"Files/Districts.csv", Encoding.UTF8)
                .ToList();
            foreach (var item in districts)
            {
                Console.WriteLine(item.Result.Name);
                db.Districts.Add(item.Result);
            }
            db.SaveChanges();
            //
            Console.WriteLine("-- Setting municipalities --");
            MunicipalityMapper csvMunicipalityMapper = new MunicipalityMapper();
            CsvParser<MunicipalityPopulation> csvMunicipalityParser = new CsvParser<MunicipalityPopulation>(csvParserOptions, csvMunicipalityMapper);
            var municipalities2020 = csvMunicipalityParser
                .ReadFromFile(@"Files/2020.csv", Encoding.UTF8)
                .ToList();
            foreach (var item in municipalities2020)
            {
                Console.WriteLine(item.Result.Name);
                db.Municipalities.Add(new Municipality { 
                    LAU1 = item.Result.LAU1,
                    LAU2 = item.Result.LAU2,
                    Name = item.Result.Name,
                });
            }
            db.SaveChanges();
            Console.WriteLine("-- Adding population data 2020 --");
            foreach (var item in municipalities2020)
            {
                Console.WriteLine(item.Result.Name);
                db.Populations.Add(new Population
                {
                    LAU2 = item.Result.LAU2,
                    Year = 2020,
                    Total = item.Result.Total,
                    Men = item.Result.Men,
                    Women = item.Result.Women,
                    Age = Convert.ToDouble(item.Result.Age),
                    MensAge = Convert.ToDouble(item.Result.MensAge),
                    WomensAge = Convert.ToDouble(item.Result.WomensAge)
                });
            }
            db.SaveChanges();
            var municipalities2019 = csvMunicipalityParser
                .ReadFromFile(@"Files/2019.csv", Encoding.UTF8)
                .ToList();
            Console.WriteLine("-- Adding population data 2019 --");
            foreach (var item in municipalities2019)
            {
                Console.WriteLine(item.Result.Name);
                db.Populations.Add(new Population
                {
                    LAU2 = item.Result.LAU2,
                    Year = 2019,
                    Total = item.Result.Total,
                    Men = item.Result.Men,
                    Women = item.Result.Women,
                    Age = Convert.ToDouble(item.Result.Age),
                    MensAge = Convert.ToDouble(item.Result.MensAge),
                    WomensAge = Convert.ToDouble(item.Result.WomensAge)
                });
            }
            db.SaveChanges();
        }
    }
}
