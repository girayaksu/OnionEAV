using System;

namespace OnionEAV.Application.Exceptions
{

    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}


