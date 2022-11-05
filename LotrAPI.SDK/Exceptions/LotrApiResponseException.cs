using System.Net;

namespace LotrAPI.SDK.Exceptions;

public class LotrApiResponseException : Exception
{
    public LotrApiResponseException(HttpStatusCode statusCode, string? statusDescription)
        : base($"Lotr API responded with status code: {statusCode} ({statusDescription})")
    { }
}