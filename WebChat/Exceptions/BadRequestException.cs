using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChat.Exceptions
{
    public class BadRequestException: CustomException
    {
        public BadRequestException(string message)
            : base(message)
        {
            StatusCode = 400;
        }
    }
}
