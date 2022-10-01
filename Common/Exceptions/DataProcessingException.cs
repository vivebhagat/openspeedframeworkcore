using System;

namespace Common.Exceptions
{
    public class DataProcessingException : Exception
    {
        public DataProcessingException(string Message):base(Message)
        {
        }
    }
}
