namespace SunriseSunsetClient.Exceptions.BadRequestExceptions
{
    /// <summary>
    /// The exception that is thrown when the parameters in the request were missing or invalid.
    /// </summary>
    public class InvalidRequestException : BadRequestException
    {
        /// <summary>
        /// Initializes a new object of the <see cref="InvalidRequestException"/> class.
        /// </summary>
        /// <param name="message">The error message of this exception.</param>
        public InvalidRequestException(string message)
            : base(message)
        {
        }
    }
}
