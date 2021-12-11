using System;

namespace RomanNumeralMath
{
    public class Arithmetic
    {
        /* function RNumCharToInt - Converts 1 roman numeral character to an integer
         * arguments
         *  rnum, a roman numeral character
         * return values
         *  the integer corresponding to the roman numeral character's value
         */
        public int RNumCharToInt(char rnum)
        {
            switch(rnum)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }
        static void Main(string[] args)
        {

            Arithmetic arithmetic = new Arithmetic();
            char rNum = 'V';
            int convertedRNum = arithmetic.RNumCharToInt(rNum);
            Console.WriteLine(rNum + " in integer form equals " + convertedRNum);
        }
    }
}
