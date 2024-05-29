using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class BadRepresentationException : Exception
    {
        public BadRepresentationException()
        {
        }
        public BadRepresentationException(string message)
            : base(message)
        {
        }
        public BadRepresentationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public class InvalidArgumentsException : Exception 
    {
        public InvalidArgumentsException() { }
        public InvalidArgumentsException(string message) : base(message) { }
        public InvalidArgumentsException(string message,Exception inner) : base(message, inner) { }
    }
}
