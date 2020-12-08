using System;

namespace SunriseSunsetClient.Exceptions
{
    /// <summary>
    /// Represents an API error.
    /// </summary>
    public class ApiRequestException : Exception
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        public virtual int ErrorCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApiRequestException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errorCode">The error code.</param>
        public ApiRequestException(string message, int errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ApiRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ApiRequestException(string message, int errorCode, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
