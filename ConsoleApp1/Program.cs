using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CaesarCipher
{
    static class CaesarCipher
    {
        public static string Encode(string input, int shift)
        {
            string output = "";
            int len = input.Length;

            for (int i = 0; i < len; i++)
            {
                int afterShift = input[i] + shift;

                output += (char)afterShift;
            }

            return output;
        }
        public static string Decode(string input, int shift)
        {
            string output = "";
            int len = input.Length;

            for (int i = 0; i < len; i++)
            {
                int afterShift = input[i] - shift;

                output += (char)afterShift;
            }

            return output;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = "SampleInput";
            int shift = 12;

            string encode = CaesarCipher.Encode(input, shift);
            string decode = CaesarCipher.Decode(encode, shift);

            Console.WriteLine($"Input: {input}");
            Console.WriteLine($"Encoded Input: {encode}");
            Console.WriteLine($"Decoded Input: {decode}");
        }
    }
}
