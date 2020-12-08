using System;
using System.Linq;
using SunriseSunsetClient.Exceptions.BadRequestExceptions;
using SunriseSunsetClient.Types;

namespace SunriseSunsetClient.Exceptions
{
    internal static class ApiExceptionParser
    {
        private static readonly IApiExceptionInfo<ApiRequestException>[] ExceptionInfos =
        {
            new BadRequestExceptionInfo<InvalidRequestException>("INVALID_REQUEST"),
            new BadRequestExceptionInfo<InvalidDateException>("INVALID_DATE"),
            new BadRequestExceptionInfo<UnknownErrorException>("UNKNOWN_ERROR"),
        };

        public static ApiRequestException Parse(Response apiResponse)
        {
            ApiRequestException exception;

            var typeInfo = ExceptionInfos.FirstOrDefault(info => apiResponse.Status == info.ErrorMessage);

            if (typeInfo is null)
            {
                exception = new ApiRequestException(apiResponse.Status, apiResponse.ErrorCode);
            }
            else
            {
                var errorMessage = apiResponse.Status;

                if (typeInfo.Type == typeof(InvalidRequestException))
                    errorMessage += ": parameters are missing or invalid.";
                else if (typeInfo.Type == typeof(InvalidDateException))
                    errorMessage += ": date parameter is missing or invalid.";
                else if (typeInfo.Type == typeof(UnknownErrorException))
                    errorMessage += ": the request could not be processed due to a server error. The request may succeed if you try again.";

                exception = Activator.CreateInstance(typeInfo.Type, errorMessage) as ApiRequestException;
            }

            return exception;
        }
    }
}
