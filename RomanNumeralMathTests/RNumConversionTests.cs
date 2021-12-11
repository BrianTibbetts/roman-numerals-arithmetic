using System;
using Xunit;
using RomanNumeralMath;

namespace RomanNumeralMathTests
{
    public class RNumConversionTests
    {
        // are all 7 roman numeral characters converted to integers correctly?
        [Fact]
        public void TestRNumCharToInt()
        {
            Arithmetic arithmetic = new Arithmetic();
            Assert.Equal(1, arithmetic.RNumCharToInt('I'));
            Assert.Equal(5, arithmetic.RNumCharToInt('V'));
            Assert.Equal(10, arithmetic.RNumCharToInt('X'));
            Assert.Equal(50, arithmetic.RNumCharToInt('L'));
            Assert.Equal(100, arithmetic.RNumCharToInt('C'));
            Assert.Equal(500, arithmetic.RNumCharToInt('D'));
            Assert.Equal(1000, arithmetic.RNumCharToInt('M'));
            
        }

        // are roman numerals in additive notation being converted to integers correctly?
        [Fact]
        public void TestRNumToIntAddNotation()
        {
            Arithmetic arithmetic = new Arithmetic();
            Assert.Equal(5, arithmetic.RNumToInt("V"));
            Assert.Equal(55, arithmetic.RNumToInt("LV"));
        }

        // how about roman numerals in subtractive notation?
        [Fact]
        public void TestRNumToIntSubNotation()
        {
            Arithmetic arithmetic = new Arithmetic();
            Assert.Equal(4, arithmetic.RNumToInt("IV"));
            Assert.Equal(109, arithmetic.RNumToInt("CIX"));
        }
    }
}
