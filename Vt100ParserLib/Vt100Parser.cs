using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Vt100ParserLib
{
    public class Vt100Parser
    {
        // Regex do usuwania sekwencji ANSI (np. \x1B[31m)
        private static readonly Regex AnsiRegex = new(@"\x1B\[[0-9;]*[A-Za-z]", RegexOptions.Compiled);

        // Konwertuje byte[] na string i usuwa sekwencje VT100
        public string Parse(byte[] data)
        {
            string raw = Encoding.ASCII.GetString(data);
            return StripAnsiSequences(raw);
        }

        // Zwraca string bez sekwencji ANSI
        public string StripAnsiSequences(string input)
        {
            return AnsiRegex.Replace(input, "");
        }

        // Zwraca pełną analizę z pokazaniem sekwencji
        public string ParseWithSequences(byte[] data)
        {
            string raw = Encoding.ASCII.GetString(data);
            StringBuilder output = new();

            int i = 0;
            while (i < raw.Length)
            {
                if (raw[i] == '\x1B') // ESC
                {
                    int start = i;
                    i++;
                    if (i < raw.Length && raw[i] == '[')
                    {
                        i++;
                        while (i < raw.Length && !"ABCDEFGHJKSTfmnsulh".Contains(raw[i]))
                            i++;
                        if (i < raw.Length)
                            i++; // Skip final char
                    }
                    string sequence = raw.Substring(start, i - start);
                    output.Append($"[SEQ:{sequence}]");
                }
                else
                {
                    output.Append(raw[i]);
                    i++;
                }
            }

            return output.ToString();
        }
    }
}

