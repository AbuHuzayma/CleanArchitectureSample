using System.Collections.Generic;
using CASample.Application.Dto;

namespace CASample.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildDistrictsFile(IEnumerable<DistrictDto> districts);
    }
}
