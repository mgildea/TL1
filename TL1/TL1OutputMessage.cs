using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL1
{
    public abstract class TL1OutputMessage
    {

        public static TL1OutputMessage Parse(string msg)
        {
            TL1OutputMessage output;
            if (TL1AcknowledgmentMessage.TryParse(msg, out output))
            {

            }
            else if (TL1ResponseMessage.TryParse(msg, out output))
            {

            }
            else if (TL1AutonomousMessage.TryParse(msg, out output))
            {

            }
            else
                throw new Exception();

            return output;
        }

    /*    public string Type {get; set;}

        public Header Header { get; set; }*/
    }

    /*public class Header
    {
        public string SID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }*/

}
