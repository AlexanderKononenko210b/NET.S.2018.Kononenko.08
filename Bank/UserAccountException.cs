using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{

    [Serializable]
    public class UserAccountException : Exception
    {
        public UserAccountException() { }
        public UserAccountException(string message) : base(message) { }
        public UserAccountException(string message, Exception inner) : base(message, inner) { }
        protected UserAccountException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
