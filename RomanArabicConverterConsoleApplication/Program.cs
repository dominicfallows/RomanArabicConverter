using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ra = new RomanArabicConverter.RomanArabicConverter();
            ushort inputNumber = 0;

            do
            {
                while (!Console.KeyAvailable)
                {
                    Console.WriteLine("Enter a whole positive number to convert to roman numerals (<=3999)");
                    Console.WriteLine("or CTRL+C/ESC to exit:");
                    try
                    {
                        inputNumber = Convert.ToUInt16(Console.ReadLine());
                        Console.WriteLine("The roman numeral for {0} is {1}", inputNumber, ra.ToRoman(inputNumber));
                        Console.WriteLine();
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("The {0} value '{1}' is outside the allowed range of the ToUInt16 type.", inputNumber.GetType().Name, inputNumber);
                        Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The {0} value '{1}' is not in a recognizable format.", inputNumber.GetType().Name, inputNumber);
                        Console.ReadLine();
                    } 
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);


        }
    }
}
