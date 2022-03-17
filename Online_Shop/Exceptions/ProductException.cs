using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Exceptions
{
    public class ProductException :Exception
    {
        public ProductException(string message) : base(message) { }
    }
}
