using System;

namespace WebAPI_Test.Exceptions
{
    public class RecordCanNotBeInserted : Exception
    {
        public RecordCanNotBeInserted()
        {
        }

        public RecordCanNotBeInserted(string message) : base(message)
        {
        }

        public RecordCanNotBeInserted(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
