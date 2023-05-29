using CleanArchitectureBase.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Exceptions
{
    public class HttpStatusException : Exception
    {
        public int StatusCode { get; private set; }

        public ECode Code { get; private set; }

        public HttpStatusException(string msg, ECode code, int statusCode = 501)
        {
            StatusCode = statusCode;
            Code = code;
        }
    }

    public class BadRequestExeption : Exception
    {
        public int StatusCode { get; private set;}

        public ECode Code { get; private set;}

        public BadRequestExeption(string msg,ECode code , int statusCode = 400) : base(msg)
        {
            StatusCode = statusCode;
            Code = code;
        }
    }
}
