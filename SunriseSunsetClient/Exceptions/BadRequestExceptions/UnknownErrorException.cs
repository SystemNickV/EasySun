namespace SunriseSunsetClient.Exceptions.BadRequestExceptions
{
    /// <summary>
    /// The exception that is thrown when request could not be processed due to a server error.
    /// The request may succeed if you try again.
    /// </summary>
    public class UnknownErrorException : BadRequestException
    {
        /// <summary>
        /// Initializes a new object of the <see cref="UnknownErrorException"/> class.
        /// </summary>
        /// <param name="message">The error message of this exception.</param>
        public UnknownErrorException(string message)
            : base(message)
        {
        }
    }
}
