using System;
using Vt100ParserLib;

class Program
{
    static void Main(string[] args)
    {
        byte[] inputData = new byte[]
        {
            0x1B, 0x5B, 0x33, 0x31, 0x6D, // ESC[31m
            (byte)'H', (byte)'e', (byte)'l', (byte)'l', (byte)'o',
            0x1B, 0x5B, 0x30, 0x6D         // ESC[0m
        };

        Vt100Parser parser = new Vt100Parser();
        string plain = parser.Parse(inputData);
        string debug = parser.ParseWithSequences(inputData);

        Console.WriteLine("Po usunięciu sekwencji:");
        Console.WriteLine(plain);
        Console.WriteLine("\nZ debugiem:");
        Console.WriteLine(debug);
    }
}
