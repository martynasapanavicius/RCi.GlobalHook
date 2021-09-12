using System;
using System.Runtime.Serialization;

namespace RCi.GlobalHook
{
    [Serializable]
    public class HookException :
        Exception
    {
        public HookException(string message) :
            base(message)
        {
        }

        protected HookException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
    }
}
