using System;
using System.IO;
using System.Collections.Generic;

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

        /* function IntToRNumStr - Converts an integer from the allowed list to a roman numeral string
         * arguments
         *  x, an integer which directly corresponds to a roman numeral character or 
         *   a pair of roman numeral characters in subtractive notation
         * return values
         *  a roman numeral string corresponding to the integer's value
         */
        public string IntToRNumStr(int x)
        {
            switch (x)
            {
                case 1:
                    return "I";
                case 4:
                    return "IV";
                case 5:
                    return "V";
                case 9:
                    return "IX";
                case 10:
                    return "X";
                case 40:
                    return "XL";
                case 50:
                    return "L";
                case 90:
                    return "XC";
                case 100:
                    return "C";
                case 400:
                    return "CD";
                case 500:
                    return "D";
                case 900:
                    return "CM";
                case 1000:
                    return "M";
                default:
                    return "";
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

        /* function RNumSum - Finds the sum of all values in a given roman numeral
         * arguments
         *  rnum, a roman numeral string
         *  sum, the current sum of roman numeral character values
         * return values
         *  the total sum of roman numeral character values as an integer
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

        /* function IntToRNum - Converts an integer to a roman numeral
         * arguments
         *  x, a positive integer
         * return values
         *  a string representing the integer as a roman numeral
         */
        public string IntToRNum(int x)
        {
            /* Create a stack of integers which correspond to relevant roman numerals,
             * any which either correspond to a single roman numeral character
             * or a pair of characters in subtractive notation. */
            Stack<int> rnumValues = new Stack<int>();
            rnumValues.Push(1);
            rnumValues.Push(4);
            rnumValues.Push(5);
            rnumValues.Push(9);
            rnumValues.Push(10);
            rnumValues.Push(40);
            rnumValues.Push(50);
            rnumValues.Push(90);
            rnumValues.Push(100);
            rnumValues.Push(400);
            rnumValues.Push(500);
            rnumValues.Push(900);
            rnumValues.Push(1000);

            return RNumFill(x, "", rnumValues, 0);
        }

        /* function RNumFill - Given an integer, builds up a string of roman numeral characters
         * arguments
         *  x, a positive integer
         *  rnum, a string containing the roman numeral
         *  rnumValues, a Stack object of integers corresponding to roman numerals
         *  rnumValuesRem, the remainder found when dividing x by the value on top of rnumValues
         * return values
         *  a string representing the integer as a roman numeral
         */
        public string RNumFill(int x, string rnum, Stack<int> rnumValues, int rnumValuesRem)
        {
            // base case: x has reached 0, meaning there are no more characters to add
            if (x <= 0)
            {
                return rnum;
            }
            // recursive case: x is greater than 0, append the next characters
            else
            {
                // Peek the stack to check the remainder
                int nextItem = rnumValues.Peek();
                int nextRem = x % nextItem;

                // If x divided by the value peeked has a remainder to pass on...
                if (nextRem < x)
                {
                    // append roman numerals to rnum representing the peeked value
                    String rnumAppend = String.Concat(rnum, IntToRNumStr(nextItem));

                    return RNumFill(
                        x - nextItem, // subtract the peeked value from the integer
                        rnumAppend,
                        rnumValues,   // continue using the stack as is
                        nextRem       // pass on the new remainder
                    );
                }
                // Else, pop the stack and peek again
                else
                {
                    rnumValues.Pop();
                    return RNumFill(
                        x,
                        rnum,
                        rnumValues,
                        rnumValuesRem
                    );
                }
            }

        }
        /* function AddRnum - Adds two roman numerals
         * arguments
         *  rnumX and rnumY, two roman numeral strings
         *  
         * return values
         *  a string representing the sum of both roman numerals
         */
        public string AddRNum(string rnumX, string rnumY)
        {
            return IntToRNum(RNumToInt(rnumX) + RNumToInt(rnumY));
        }
        static void Main(string[] args)
        {
            // Accept the user's input
            Console.WriteLine("Provide two roman numerals to add.");
            Console.WriteLine("Roman numeral 1: ");
            string rnum1 = Console.ReadLine();
            Console.WriteLine("Roman numeral 2: ");
            string rnum2 = Console.ReadLine();

            // Add the roman numerals and display the result to the user
            Arithmetic arithmetic = new Arithmetic();
            string rnumSum = arithmetic.AddRNum(rnum1, rnum2);
            Console.WriteLine("Sum as a Roman Numeral: " + rnumSum);
            Console.WriteLine("Sum as an Integer: " + arithmetic.RNumToInt(rnumSum));
        }
    }
}
