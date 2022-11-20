using System;
using System.Runtime.Serialization;

namespace ExceptionsDemoConsoleApp1.BusinessLayer
{
    [Serializable]
    internal class OddInputException : Exception
    {
        public OddInputException()
        {
        }

        public OddInputException(string message) : base(message)
        {
        }

        public OddInputException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OddInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}