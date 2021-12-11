﻿using System;

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
            // Find the value of the current roman numeral character
            int rnumVal = RNumCharToInt(rnum[0]);   
            // base case: the roman numeral string has 1 or less characters left
            if (rnum.Length <= 1)
            {
                return sum + rnumVal;
            }

            // recursive case: the roman numeral string is longer than 1 character
            else {
                /* To decide whether the roman numeral is in subtractive notation,
                 * compare the first and second characters. */
                if (rnumVal < RNumCharToInt(rnum[1]))
                {
                    // subtractive notation: subtract the character's value from the sum
                    return RNumSum(rnum.Substring(1), sum - rnumVal);
                }
                else
                {
                    // additive notation: add the character's value to the sum
                    return RNumSum(rnum.Substring(1), sum + rnumVal);
                }
            }
        }
        static void Main(string[] args)
        {

            Arithmetic arithmetic = new Arithmetic();
            string rnum = "V";
            int convertedrnum = arithmetic.RNumCharToInt(rnum[0]);
            Console.WriteLine("The roman numeral character " + rnum + " in integer form equals " + convertedrnum);

            string fullrnum = "CIX";
            int convertedfullrnum = arithmetic.RNumToInt(fullrnum);
            Console.WriteLine("The roman numeral " + fullrnum + " in integer form equals " + convertedfullrnum);
        }
    }
}
