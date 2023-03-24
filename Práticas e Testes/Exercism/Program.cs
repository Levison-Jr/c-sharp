using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism
{
    public static class ReverseString
    {
        public static string Reverse(string input)
        {
            string reverse = "";
            for (int i = input.Length - 1; i <= 0; i--)
            {
                Console.WriteLine(i);
                reverse += input[i];
            }
            return reverse;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string teste = "cool";
            Console.WriteLine(ReverseString.Reverse(teste));
        }
    }
}
