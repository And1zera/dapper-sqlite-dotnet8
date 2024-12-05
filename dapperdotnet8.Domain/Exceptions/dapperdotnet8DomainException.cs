using dapperdotnet8.Domain.Enum;
using System.Net;

namespace dapperdotnet8.Domain.Exceptions;

public class dapperdotnet8DomainException : Exception
{
    public ErrorCodeEnum ErrorCode { get; set; }
    public HttpStatusCode? StatusCode { get; set; }

    public dapperdotnet8DomainException(string message, ErrorCodeEnum errorCode, HttpStatusCode? statusCode = null) : base(message)
    {
        this.ErrorCode = errorCode;
        this.StatusCode = statusCode;
    }

    public dapperdotnet8DomainException(string message, ErrorCodeEnum errorCode, Exception innerException, HttpStatusCode? statusCode = null) : base(message, innerException)
    {
        this.ErrorCode = errorCode;
        this.StatusCode = statusCode;
    }
}