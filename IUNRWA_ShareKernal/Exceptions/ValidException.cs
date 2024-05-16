using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_ShareKernal.Exceptions
{
    public  class ValidException :Exception
    {
        public ValidException(string message) : base(message) { }

        public ValidException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
