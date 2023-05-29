using AutoMapper;
using CleanArchitectureBase.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Mappings.Converters
{
    public class DateTimeTypeConverter : ITypeConverter<DateTime?, int?>, ITypeConverter<int?, DateTime?>, ITypeConverter<DateTime, int>, ITypeConverter<int, DateTime>, ITypeConverter<DateOnly?, int?>, ITypeConverter<int?, string>
    {
        public int? Convert(DateTime? source, int? destination, ResolutionContext context)
        {
            return source != null ? ConvertDateTime.DateTimeToUnixTimeStamp(source.Value) : (int?)null;
        }

        public DateTime? Convert(int? source, DateTime? destination, ResolutionContext context)
        {
            return ConvertDateTime.UnixTimeStampToDateTime(source);
        }

        public DateTime Convert(int source, DateTime destination, ResolutionContext context)
        {
            return ConvertDateTime.UnixTimeStampToDateTime(source).Value;
        }

        public int Convert(DateTime source, int destination, ResolutionContext context)
        {
            return ConvertDateTime.DateTimeToUnixTimeStamp(source).Value;
        }
        public int? Convert(DateOnly? source, int? destination, ResolutionContext context)
        {
            return source != null ? ConvertDateTime.DateOnlyToUnixTimeStamp(source.Value) : (int?)null;
        }

        public int? Convert(string source, int? destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }

        public string Convert(int? source, string destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
