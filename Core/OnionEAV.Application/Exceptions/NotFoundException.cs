using System;

namespace OnionEAV.Application.Exceptions
{

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string name, object key)
            : base($"{name} bulunamadı. ID: {key}")
        {
        }
    }
}


