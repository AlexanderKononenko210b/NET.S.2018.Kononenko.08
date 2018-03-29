using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    [Serializable]
    public class AccessExceptions : Exception
    {
        public AccessExceptions() { }
        public AccessExceptions(string message) : base(message) { }
        public AccessExceptions(string message, Exception inner) : base(message, inner) { }
        protected AccessExceptions(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
