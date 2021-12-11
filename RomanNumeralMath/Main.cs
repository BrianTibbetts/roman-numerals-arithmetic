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

        /* function RNumToInt - Converts a roman numeral to an integer
         * arguments
         *  rnum, a roman numeral string 
         * return values
         *  an integer corresponding to the roman numeral's value
         */
        public int RNumToInt(string rnum)
        {
            return (RNumSum(rnum, 0));
        }

        /* function RNumSum - Finds the sum of all roman numeral characters in a roman numeral
         * arguments
         *  rnum, a roman numeral string
         *  sum, the current sum of roman numeral character values
         * return values
         *  the total sum of roman numeral character values
         *      -see the base case and recursive case for more information
         */
        public int RNumSum(string rnum, int sum)
        {
            // base case: the roman numeral string has 1 character left
            if (rnum.Length == 1)
            {
                return sum + RNumCharToInt(rnum[0]);
            }

            // recursive case: the roman numeral string is longer than 1 character
            else { 
                /* To decide whether the roman numeral is in subtractive notation,
                 * compare the first and second characters. */

                    // subtractive notation: subtract the character's value from the sum

                    // additive notation: add the character's value to the sum
            }
        }
        static void Main(string[] args)
        {

            Arithmetic arithmetic = new Arithmetic();
            string rnum = "V";
            int convertedRNum = arithmetic.RNumCharToInt(rnum[0]);
            Console.WriteLine(rnum + " in integer form equals " + convertedRNum);
        }
    }
}
