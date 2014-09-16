using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL1
{
    public class TL1InputMessage
    {
        public CommandCode CommandCode { get; set; }
        public StagingBlock StagingBlock { get; set; }
        public PayloadBlock PayloadBlock { get; set; }


        public static bool TryParse(string msg, out TL1InputMessage inputmessage)
        {
            inputmessage = null;
            try
            {
                inputmessage = TL1InputMessage.Parse(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static TL1InputMessage Parse(string msg)
        {
            string[] pieces = msg.ToUpper().Substring(0, msg.IndexOf(TL1MessageElements.TERMINATOR)).Split(new char[] { Char.Parse(TL1MessageElements.SEPARATOR) }, StringSplitOptions.None);

            return new TL1InputMessage()
            {
                CommandCode = new CommandCode(pieces[0]),
                StagingBlock = new StagingBlock(pieces.Skip(1).Take(4).ToArray()),
                PayloadBlock = new PayloadBlock(pieces[pieces.Length -1])
            };
        }
        
        public override string ToString()
        {
            return CommandCode.ToString() + TL1MessageElements.SEPARATOR + StagingBlock.ToString() + TL1MessageElements.SEPARATOR + PayloadBlock.ToString() + TL1MessageElements.TERMINATOR;
        }

    }

    public class CommandCode
    {
        public string Verb { get; set; }
        public string Modifier1 { get; set; }
        public string Modifier2 { get; set; }

        public CommandCode(string command)
        {
            string[] pieces = command.Split(new char[] { Char.Parse(TL1MessageElements.COMMAND_SEPARATOR) }, StringSplitOptions.None);

            Verb = pieces[0];

            int i = pieces.Length;
            if(i > 1)
            {
                Modifier1 = pieces[1];

                if (i > 2)
                    Modifier2 = pieces[2];
            }
        }

        public override string ToString()
        {
            string str = Verb;

            if (!String.IsNullOrEmpty(Modifier1))
            {
                str += TL1MessageElements.COMMAND_SEPARATOR + Modifier1;

                if (!String.IsNullOrEmpty(Modifier2))
                    str += TL1MessageElements.COMMAND_SEPARATOR + Modifier2;
            }

            return str;
        }
    }

    public class StagingBlock
    {
        public string TID { get; set; }
        public string AID { get; set; }
        public string CTAG { get; set; }
        public string GeneralBlock { get; set; }

        public StagingBlock(string[] pieces)
        {
            TID = pieces[0];
            AID = pieces[1];
            CTAG = pieces[2];
            GeneralBlock = pieces[3];
        }

        public override string ToString()
        {
            return TID + TL1MessageElements.SEPARATOR + AID + TL1MessageElements.SEPARATOR + CTAG + TL1MessageElements.SEPARATOR + GeneralBlock;
        }
    }

    public class PayloadBlock
    {
        public string DataBlock { get; set; }

        public PayloadBlock(string data)
        {
            DataBlock = data;
        }

        public override string ToString()
        {
            return DataBlock;
        }
    }
}
