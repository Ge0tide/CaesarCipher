using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CaesarCipher
{
    static class CaesarCipher
    {
        private static List<char> letterList = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        public static string Name { get { return "Caesar Cipher"; } }

        public static string Code(string text, int key) // Method used to code
        {
            int index, newIndex;
            string result = string.Empty;
            text = text.Trim();
            
            foreach(char letter in text)
            {
                if(letterList.Contains(char.ToUpper(letter)))
                {
                    bool isUpper = char.IsUpper(letter);

                    index = letterList.IndexOf(letterList.First(x => x == char.ToUpper(letter)));
                    newIndex = index + key;
                    if(newIndex > 25)
                    {
                        newIndex -= 25;
                    }
                    else if (newIndex < 0)
                    {
                        newIndex += 25;
                    }
                    result += isUpper == true ? letterList[newIndex] : char.ToLower(letterList[newIndex]);
                }
                else if(char.IsWhiteSpace(letter))
                {
                    result += letter;
                }
            }
            return result;
        }
        public static string Decode(string text, int key)
        {
            string result = string.Empty;
            result = Code(text, -key);
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int shiftVal = 15;
            
            while(true)
            {
                Console.Write("Input shift value: ");
                try
                { 
                    shiftVal = int.Parse(Console.ReadLine());
                    if(shiftVal > 24)
                    {
                        throw new Exception();
                    }
                    else if(shiftVal < 0)
                    {
                        throw new Exception();
                    }
                    Console.Clear();
                }
                catch
                {
                    continue;
                }
                Console.Write($"[Shift = {shiftVal}]\n1. Code\n2. Decode\n3. Exit\n\nChoice: ");
                input = Console.ReadLine();
                Console.Clear();
                try
                {
                    int x;
                    int.TryParse(input, out x);

                    if(x == 1)
                    {
                        Console.Write("Input: ");
                        input = Console.ReadLine();

                        Console.WriteLine($"\nOutput: {CaesarCipher.Code(input, shiftVal)}\n\n");
                    }
                    else if (x == 2)
                    {
                        Console.Write("Input: ");
                        input = Console.ReadLine();
                        
                        Console.WriteLine($"\nOutput: {CaesarCipher.Decode(input, shiftVal)}\n\n");
                    }
                    else if(x == 3)
                    {
                        Environment.Exit(Environment.ExitCode);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Error 1 - Please input a valid constrained number!\n\n");
                    continue;
                } 
            }
        }
    }
}
