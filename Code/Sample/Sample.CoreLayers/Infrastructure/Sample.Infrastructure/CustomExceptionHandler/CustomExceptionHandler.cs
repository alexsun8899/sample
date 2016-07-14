using System;

namespace Sample.Infrastructure.CustomExceptionHandler
{
    public class CustomExceptionHandler : Exception
    {
        public CustomExceptionHandler(string message) : base(message) { }

    }
}
