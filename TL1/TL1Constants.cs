using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL1
{
    public abstract class TypeSafeEnum
    {
        private readonly int value;
        private readonly string name;

        protected TypeSafeEnum(int value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }


    }


    public sealed class TL1AckCode : TypeSafeEnum
    { 
        private TL1AckCode(int value, string name) : base(value, name) {}
       
        public static readonly TL1AckCode IN_PROGRESS = new TL1AckCode(1, "IP");
        public static readonly TL1AckCode NO_ACKNOWLEDGEMENT = new TL1AckCode(2, "NA");
        public static readonly TL1AckCode NO_GOOD = new TL1AckCode(3, "NG");
        public static readonly TL1AckCode OK = new TL1AckCode(4, "OK");
        public static readonly TL1AckCode PRINTOUT_FOLLOWS = new TL1AckCode(5, "PF");
        public static readonly TL1AckCode REPEAT_LATER = new TL1AckCode(6, "RL");

        public static TL1AckCode ParseCode(string name)
        {
            if (name == IN_PROGRESS.ToString())
                return IN_PROGRESS;
            else if (name == NO_ACKNOWLEDGEMENT.ToString())
                return NO_ACKNOWLEDGEMENT;
            else if (name == NO_GOOD.ToString())
                return NO_GOOD;
            else if (name == OK.ToString())
                return OK;
            else if (name == PRINTOUT_FOLLOWS.ToString())
                return PRINTOUT_FOLLOWS;
            else if (name == REPEAT_LATER.ToString())
                return REPEAT_LATER;
            else
                throw new Exception();
        }
    }

    //public static class TL1AckCodes
    //{
    //    public const string IN_PROGRESS = "IP";
    //    public const string NO_ACKNOWLEDGEMENT = "NA";
    //    public const string NO_GOOD = "NG";
    //    public const string OK = "OK";
    //    public const string PRINTOUT_FOLLOWS = "PF";
    //    public const string REPEAT_LATER = "RL";
    //}

    public static class TL1ErrorCodes
    {
        public const string INPUT_COMMAND_NOT_VALID = "ICNV";
        public const string INPUT_INVALID_TARGET_IDENTIFIER = "IITA";
        public const string INPUT_INVALID_ACCESS_IDENTIFIER = "IIAC";
        public const string INPUT_DATA_NOT_VALID = "IDNV";
        public const string INPUT_NON_NULL_UNIMPLEMENTED = "INUP";
        public const string INPUT_INVALID_SYNTAX_OR_PUNCTUATION = "IISP";
        public const string PRIVILEGE_ILLEGAL_FIELD_CODE = "PIFC";
    }

    public static class TL1AlarmCodes
    {
        public const string AUTO_MSG = "A ";
        public const string CRITICAL = "*C";
        public const string MAJOR = "**";
        public const string MINOR = "* ";
        public const string WARNING = "*W";
    }

    public static class TL1CompletionCodes
    {
        public const string COMPLD = "COMPLD";
        public const string DELAY = "DELAY";
        public const string DENY = "DENY";
        public const string PRTL = "PRTL";
        public const string RTRV = "RTRV";
    }

    public static class TL1OutputMsgTypes
    {
        public const int ACK = 4;
        public const int ALL = 7;
        public const int NOTIFICATION = 1;
        public const int RESPONSE = 2;
        
    }

    public static class TL1TerminationCodes
    {
        public const string END = "\r\n;";
        public const string MORE_TO_COME = "\r\n>";
        public const string ACKNOWLEDGMENT = "\r\n<";
    }

    public static class TL1MessageElements
    {
        public const string TERMINATOR = ";";
        public const string SEPARATOR = ":";
        public const string COMMAND_SEPARATOR = "-";
        public const string DIVIDER = ",";
        public const string PLACEHOLDER = ",";
    }
}
