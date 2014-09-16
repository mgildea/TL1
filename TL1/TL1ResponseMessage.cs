using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL1
{
    class TL1ResponseMessage : TL1OutputMessage
    {
        public static TL1ResponseMessage Parse(string msg)
        {
            return new TL1ResponseMessage(msg);
        }

        public static bool TryParse(string msg, out TL1OutputMessage outputmessage)
        {
            outputmessage = null;
            try
            {
                outputmessage = TL1ResponseMessage.Parse(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TL1ResponseMessage(string msg)
        {

        }
    }
}
