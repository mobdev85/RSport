﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URSpot.Core.Api.Exceptions
{
    public class NoInternetConnectionException : Exception
    {
        public NoInternetConnectionException(string message) : base(message)
        { }
        public NoInternetConnectionException() { }
    }
}
