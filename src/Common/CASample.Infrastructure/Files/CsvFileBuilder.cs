using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CASample.Application.Common.Interfaces;
using CASample.Application.Dto;
using CASample.Infrastructure.Files.Maps;
using CsvHelper;

namespace CASample.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildDistrictsFile(IEnumerable<DistrictDto> cities)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Context.RegisterClassMap<DistrictMap>();
                csvWriter.WriteRecords(cities);
            }

            return memoryStream.ToArray();
        }
    }
}
