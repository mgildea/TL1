using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL1
{
    class TL1AcknowledgmentMessage : TL1OutputMessage
    {
        public TL1AckCode Code { get; set; }
        public string CTAG { get; set; }
        public string Terminator { get; set; }


        public static TL1AcknowledgmentMessage Parse(string msg)
        {
            //TODO: dont split on space...split on new line....or find terminator
            string[] pieces = msg.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
         
            return new TL1AcknowledgmentMessage()
            {
                Code = TL1AckCode.ParseCode(pieces[0]),
                CTAG = pieces[1],
                Terminator = pieces[pieces.Length -1]
            };
        }

        public static bool TryParse(string msg, out TL1OutputMessage outputmessage)
        {
            outputmessage = null;
            try
            {
                outputmessage = TL1AcknowledgmentMessage.Parse(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }



       
    }
}
