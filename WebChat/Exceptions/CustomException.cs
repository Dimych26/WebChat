﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChat.Exceptions
{
    public class CustomException: Exception
    {
        public int StatusCode { get; set; }
        public CustomException(string message)
            : base(message)
        {
        }
    }
}
