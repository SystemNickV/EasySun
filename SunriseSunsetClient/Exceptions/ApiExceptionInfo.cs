using System;

namespace SunriseSunsetClient.Exceptions
{
    internal interface IApiExceptionInfo<out T>
        where T : ApiRequestException
    {
        int ErrorCode { get; }

        string ErrorMessage { get; }

        Type Type { get; }
    }

    internal class BadRequestExceptionInfo<T> : IApiExceptionInfo<T>
        where T : ApiRequestException
    {
        public int ErrorCode => BadRequestException.BadRequestErrorCode;

        public string ErrorMessage { get; }

        public Type Type => typeof(T);

        public BadRequestExceptionInfo(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
