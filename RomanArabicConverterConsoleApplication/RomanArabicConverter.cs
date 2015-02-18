using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanArabicConverter
{
    public class RomanArabicConverter
    {
        /* private Dictionary<char, int> _raDict = new Dictionary<char, int>(7)
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        }; */

        public String ToRoman(ushort inputNumber)
        {
            if (inputNumber > 3999)
            {
                return "Roman numerals can only go upto 3999 usig I-M keys";
            }

            string outputString = "";
            int remainingNumber = inputNumber;

            // First we deal with the thousands
            int thousands = remainingNumber / 1000; //how many thousands do we have? 
            remainingNumber -= (thousands * 1000); //remove the value of the number of thousands from remaming to use later
            while (thousands > 0) //loop through the thousands and add the roman numeral to the output string
            {
                outputString += 'M';
                thousands--;
            }

            // Next we deal with the hundreds
            int hundreds = remainingNumber / 100;
            remainingNumber -= (hundreds * 100);
            outputString += HandleDigits(hundreds, "hundreds");

            // Next we deal with the tens
            int tens = remainingNumber / 10;
            remainingNumber -= (tens * 10);
            outputString += HandleDigits(tens, "tens");

            // Next we deal with the rest
            outputString += HandleDigits(remainingNumber, "ones");
            
            return outputString;

        }

        static int[] SplitIntToArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }

        static string HandleDigits(int numOf, string type) {

            string outputString = "";
            Dictionary<int, string> digits = new Dictionary<int, string>();
            switch (type)
            {
                case "hundreds":
                    digits.Add(9, "CM");
                    digits.Add(5, "D");
                    digits.Add(4, "CD");
                    digits.Add(1, "C");
                    break;
                case "tens":
                    digits.Add(9, "XC");
                    digits.Add(5, "L");
                    digits.Add(4, "XL");
                    digits.Add(1, "X");
                    break;
                case "ones":
                    digits.Add(9, "IX");
                    digits.Add(5, "V");
                    digits.Add(4, "IV");
                    digits.Add(1, "I");
                    break;
            }
            
            while (numOf > 0)
            {

                if (numOf == 9)
                {
                    outputString += digits[9];
                    numOf -= 9;
                }
                else if (numOf >= 5)
                {
                    outputString += digits[5];
                    numOf -= 5;
                }
                else if (numOf == 4)
                {
                    outputString += digits[4];
                    numOf -= 4;
                }
                else
                {
                    outputString += digits[1];
                    numOf--;
                }
            }
            return outputString;
        }
 
    }
}
