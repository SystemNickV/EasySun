using System;

namespace SunriseSunsetClient.Exceptions
{
    /// <summary>
    /// Represents an error from Sunrise Sunset API with 400 Bad Request HTTP status.
    /// </summary>
    public abstract class BadRequestException : ApiRequestException
    {
        /// <inheritdoc />
        public override int ErrorCode => BadRequestErrorCode;

        /// <summary>
        /// Represent error code number.
        /// </summary>
        public const int BadRequestErrorCode = 400;

        /// <summary>
        /// Represent error description.
        /// </summary>
        public const string BadRequestErrorDescription = "Bad Request: ";

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        protected BadRequestException(string message)
            : base(message, BadRequestErrorCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        protected BadRequestException(string message, Exception innerException)
            : base(message, BadRequestErrorCode, innerException)
        {
        }
    }
}
