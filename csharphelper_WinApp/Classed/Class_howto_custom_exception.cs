
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

  namespace  howto_custom_exception

 { 

// Thrown if a file size contains an unknown exception.
    public class UnknownExtensionException : FormatException
    {
        public string Extension = "";
        public UnknownExtensionException()
            : base()
        {
        }
        public UnknownExtensionException(string extension)
            : base()
        {
            Extension = extension;
        }
        public UnknownExtensionException(string extension, string message)
            : base(message)
        {
            Extension = extension;
        }
        public UnknownExtensionException(string extension,
            string message, Exception inner_exception)
            : base(message, inner_exception)
        {
            Extension = extension;
        }
        public UnknownExtensionException(string extension,
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Extension = extension;
        }
    }

}