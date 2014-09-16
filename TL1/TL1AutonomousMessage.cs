using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL1
{
    class TL1AutonomousMessage : TL1OutputMessage
    {
       public static TL1AutonomousMessage Parse(string msg)
        {
            return new TL1AutonomousMessage(msg);
        }

        public static bool TryParse(string msg, out TL1OutputMessage outputmessage)
        {
            outputmessage = null;
            try
            {
                outputmessage = TL1AutonomousMessage.Parse(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }



        public TL1AutonomousMessage(string msg)
        {

        }
    }
}
