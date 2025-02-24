using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PowerBsRise
{
    public class BroadsignResourceException : Exception
    {
        public BroadsignResourceException() { }

    }
    public class BroadsignResourceNotFoundException : Exception
    {
        public BroadsignResourceNotFoundException()
        {
        }

        public BroadsignResourceNotFoundException(string? message) : base(message)
        {
        }

        public BroadsignResourceNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BroadsignResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
