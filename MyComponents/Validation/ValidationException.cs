using System;

namespace MyComponents.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        { }
    }
}