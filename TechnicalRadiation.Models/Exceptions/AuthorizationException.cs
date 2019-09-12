using System;

namespace TechnicalRadiation.Models.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException() : base("Model is not properly formatted") {}
        public AuthorizationException(string message) : base(message) {}
        public AuthorizationException(string message, Exception inner) : base (message, inner) {}
    }
}