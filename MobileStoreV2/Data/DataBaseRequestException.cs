using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreV2.Data
{


    [Serializable]
    public class DataBaseRequestException : Exception
    {
        public DataBaseRequestException() { }
        public DataBaseRequestException(string message) : base(message) { }
        public DataBaseRequestException(string message, Exception inner) : base(message, inner) { }
        protected DataBaseRequestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
