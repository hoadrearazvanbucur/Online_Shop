﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException(string message) : base(message) { }
    }
}
