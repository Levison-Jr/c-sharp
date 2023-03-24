using System;

namespace Program
{   
    class Mat
    {
        public static int Soma(params int[] numeros)
        {
            int somatorio = 0;

            foreach (var item in numeros)
            {
                somatorio += item;
            }

            return somatorio;
        }
    }
    static class AnalisarTriangulo
    {
        static string resultadoAnalise;

        public static void Analisar(float[] arr)
        {
            Array.Sort(arr);
            Array.Reverse(arr);

            float A = arr[0], B = arr[1], C = arr[2];

            if (A >= (B + C))
            {
                resultadoAnalise = "NAO FORMA TRIANGULO\n";
            }
            else
            {
                if (Math.Pow(A, 2) == Math.Pow(B, 2) + Math.Pow(C, 2))
                {
                    resultadoAnalise = "TRIANGULO RETANGULO\n";
                }

                else if (Math.Pow(A, 2) > Math.Pow(B, 2) + Math.Pow(C, 2))
                {
                    resultadoAnalise = "TRIANGULO OBTUSANGULO\n";
                }

                else if (Math.Pow(A, 2) < Math.Pow(B, 2) + Math.Pow(C, 2))
                {
                    resultadoAnalise = "TRIANGULO ACUTANGULO\n";
                }

                if (A == B && B == C)
                {
                    resultadoAnalise += "TRIANGULO EQUILATERO\n";
                }
                else if ((A == B) || (B == C) || (C == A))
                {
                    resultadoAnalise += "TRIANGULO ISOSCELES\n";
                }
            }

            Console.Write(resultadoAnalise);
        }
    }
    class Beecrowd
    {
        static void Main(string[] args)
        {
            string teste = "UUAUUC";
            Console.WriteLine(teste.Length);
        }
    }
}
