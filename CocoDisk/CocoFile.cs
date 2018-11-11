using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoDisk
{
    public enum CocoFileType
    {
        Ascii,
        Basic,
        Binary
    }

    class CocoFile
    {
        public string Name = "";
        public byte[] Data = new byte[0];
        public CocoFileType Type;
        public int ErrorCount;  // Number of bad sectors

        public override string ToString()
        {
            return  Name.PadRight(12) + " " + (ErrorCount == 0 ? " " : "X") + " " + Data.Length;
        }

        /// <summary>
        /// Return ASCII, converting '\r' to CR and stripping '\0's
        /// </summary>
        public string GetText(string cr)
        {
            // Show basic file
            if (Type == CocoFileType.Basic)
            {
                return GetBasic(cr);
            }
            // Show ASCII file
            StringBuilder sb = new StringBuilder();
            if (Type == CocoFileType.Ascii)
            {
                // Get ASCII
                foreach (var b in Data)
                {
                    if (b == '\r')
                        sb.Append(cr);
                    else if (b != 0)
                        sb.Append((char)b);
                }
                return sb.ToString();
            }
            // Show binary file
            for (int i = 0;  i < Data.Length;  i += 16)
            {
                sb.Append(i.ToString("X4"));
                sb.Append(": ");
                for (int j = 0;  j < 16;  j++)
                {
                    if (i + j < Data.Length)
                        sb.Append(((int)Data[i + j]).ToString("X2") + " ");
                    else
                        sb.Append("   ");
                }
                sb.Append(" ");
                for (int j = 0;  j < 16;  j++)
                {
                    if (i + j < Data.Length)
                        sb.Append(Data[i+j] >= 32 && Data[i+j] < 128 ? (char)Data[i+j] : '.');
                }
                sb.Append(cr);
            }
            return sb.ToString();
        }

        // Return ASCII, converting '\r' to CR and stripping '\0's
        private string GetBasic(string cr)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                int index = 5;
                while (true)
                {
                    sb.Append(256 * Data[index] + Data[index + 1]);
                    sb.Append(" ");
                    index += 2;
                    while (Data[index] != 0)
                    {
                        int b = Data[index++];
                        if (b < 128)
                        {
                            sb.Append((char)b);
                        }
                        else if (b == 255)
                        {
                            b = Data[index++];
                            if (b < 128)
                                sb.Append("?" + (char)b);
                            else
                                sb.Append(sCommands2[b - 128]);
                        }
                        else
                        {
                            sb.Append(sCommands[b - 128]);
                        }
                    }
                    sb.Append(cr);

                    if (Data[index + 1] == 0)
                        break;
                    index += 3;
                }
            }
            catch (Exception ex)
            {
                sb.Append("\r\n\r\nError parsing basic: " + ex.Message + "\r\n");
            }
            return sb.ToString();
        }

        readonly string[] sCommands =
        {
            // Basic (start at $0x80)
            "FOR", "GO", "REM", "'", "ELSE", "IF", "DATA", "PRINT",
            "ON", "INPUT", "END", "NEXT", "DIM", "READ", "RUN", "RESTORE",
            "RETURN", "STOP", "POKE", "CONT", "LIST", "CLEAR", "NEW", "CLOAD",
            "CSAVE", "OPEN", "CLOSE", "LLIST", "SET", "RESET", "CLS", "MOTOR",
            "SOUND", "AUDIO", "EXEC", "SKIPF", "TAB(", "TO", "SUB", "THEN",
            "NOT", "STEP", "OFF", "+", "-", "*", "/", "^",
            "AND", "OR", ">", "=", "<",

            // Extended basic (start at $0xB5)
            "DEL", "EDIT", "TRON", "TROFF", "DEF", "LET", "LINE", "PCLS",
            "PSET", "PRESET", "SCREEN", "PCLEAR", "COLOR", "CIRCLE", "PAINT", "GET",
            "PUT", "DRAW", "PCOPY", "PMODE", "PLAY", "DLOAD", "RENUM", "FN",
            "USING",

            // Disk basic (start at $CE)
            "DIR", "DRIVE", "FIELD", "FILES", "KILL", "LOAD", "LSET", "MERGE",
            "RENAME", "RSET", "SAVE", "WRITE", "VERIFY", "UNLOAD", "DSKINI", "BACKUP",
            "COPY", "DSKI$", "DSKO$",
            "DOS", // NOTE: I changed this to JMS for my own uses

            // Coco 3 baisc (start at $E2)
            "WIDTH", "PALETTE", "HSCREEN", "LPOKE", "HCLS", "HCOLOR", "HPAINT", "HCIRCLE",
            "HLINE", "HGET", "HPUT", "HBUFF", "HPRINT", "ERR", "BRK", "LOCATE",
            "HSTAT", "HSET", "HRESET", "HDRAW", "CMP", "RGB", "ATTR",

            "?","?","?","?","?","?","?","?","?","?","?","?","?","?","?","?",
        };

        readonly string[] sCommands2 =
        {
            // Basic (start at $0x80)
            "SGN", "INT", "ABS", "USR", "RND", "SIN", "PEEK", "LEN",
            "STR$", "VAL", "ASC", "CHR$", "EOF", "JOYSTK", "LEFT$", "RIGHT$",
            "MID$", "POINT", "INKEY$", "MEM",

            // Extended basic (start at $94)
            "ATN", "COS", "TAN", "EXP", "FIX", "LOG", "POS", "SQR",
            "HEX$", "VARPTR", "INSTR", "TIMER", "PPOINT", "STRING$",

            // Disk basic (start at $A2)
            "CVN", "FREE", "LOC", "LOF", "MKN$", "AS",

            // Coco 3 basic (start at $A8)
            "LPEEK", "BUTTON", "HPOINT", "ERNO", "ERLIN",

            "?","?","?","?","?","?","?","?","?","?","?","?","?","?","?","?",
            "?","?","?","?","?","?","?","?","?","?","?","?","?","?","?","?",
            "?","?","?","?","?","?","?","?","?","?","?","?","?","?","?","?",
            "?","?","?","?","?","?","?","?","?","?","?","?","?","?","?","?",
            "?","?","?","?","?","?","?","?","?","?","?","?","?","?","?","?",
            "?","?","?","?","?","?","?","?","?","?","?","?","?","?","?","?",
        };

    }
}
