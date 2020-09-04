using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Exceptions
{
    public class ECExceptions:ApplicationException
    {
        public ECExceptions() : base() { }
        public ECExceptions(string message) : base(message) { }
        public ECExceptions(string message, Exception innerException) : base(message, innerException) { }

    }
}
