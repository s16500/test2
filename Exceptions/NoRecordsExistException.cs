using System;

namespace WebAPI_Test.Exceptions
{
    public class NoRecordsExistException : Exception
    {
        public NoRecordsExistException()
        {
        }

        public NoRecordsExistException(string message) : base(message)
        {
        }

        public NoRecordsExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
