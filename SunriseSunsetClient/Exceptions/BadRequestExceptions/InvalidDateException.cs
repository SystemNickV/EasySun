namespace SunriseSunsetClient.Exceptions.BadRequestExceptions
{
    /// <summary>
    /// The exception that is thrown when the date parameter in the request was missing or invalid.
    /// </summary>
    public class InvalidDateException : BadRequestException
    {
        /// <summary>
        /// Initializes a new object of the <see cref="InvalidDateException"/> class.
        /// </summary>
        /// <param name="message">The error message of this exception.</param>
        public InvalidDateException(string message)
            : base(message)
        {
        }
    }
}
