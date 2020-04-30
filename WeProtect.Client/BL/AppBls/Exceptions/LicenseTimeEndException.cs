using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeProtect.Client.BL.AppBLs.Exceptions
{
    public class LicenseTimeEndException : Exception
    {
        public LicenseTimeEndException()
        {
        }

        public LicenseTimeEndException(string message) : base(message)
        {
        }

        public LicenseTimeEndException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LicenseTimeEndException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
