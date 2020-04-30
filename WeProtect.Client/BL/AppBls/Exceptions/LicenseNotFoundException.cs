using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeProtect.Client.BL.AppBLs.Exceptions
{
    class LicenseNotFoundException : Exception
    {
        public LicenseNotFoundException()
        {
        }

        public LicenseNotFoundException(string message) : base(message)
        {
        }

        public LicenseNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LicenseNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
