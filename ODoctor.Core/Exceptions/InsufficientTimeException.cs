using System;
using System.Runtime.Serialization;

namespace ODoctor.Core.Exceptions
{
    [Serializable]
    public class InsufficientTimeException: Exception
    {
        public InsufficientTimeException() { }
        public InsufficientTimeException (string message)
            : base(message) { }
        public InsufficientTimeException (string message, Exception inner) 
            :base(message, inner) { }
        public InsufficientTimeException(SerializationInfo info, StreamingContext context)
            :base(info, context) { }
    }
}
