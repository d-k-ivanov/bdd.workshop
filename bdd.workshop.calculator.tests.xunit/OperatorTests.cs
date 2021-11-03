using System;
using Xunit;

namespace bdd.workshop.calculator.tests.xunit
{
    public class OperatorTests
    {
        [Fact]
        [Trait("TestType", "UT")]
        public void BasicAdd()
        {
            int a = 1;
            int b = 2;
            double result = 3;
            Assert.True(Operator.Add(a, b) == result);
        }
        [Fact]
        [Trait("TestType", "UT")]
        public void BasicMultiply()
        {
            int a = 10;
            int b = 4;
            double result = 40;
            Assert.True(Operator.Multiply(a, b) == result);
        }

        [Theory(DisplayName ="Division Theory")]
        [Trait("TestType", "Theory")]
        [InlineData(20, 4, 5)]
        [InlineData(10, 4, 2.5)]
        public void DivisionTheory(int a, int b, double result)
        {
            Assert.True(Operator.Divide(a, b) == result);
        }
        //[Fact]
        //[Trait("TestType", "UT")]
        //public void BasicDivide()
        //{
        //    int a = 20;
        //    int b = 4;
        //    double result = 5;
        //    Assert.True(Operator.Divide(a, b) == result);
        //}

        [Fact]
        [Trait("TestType", "UT")]
        public void BasicSubstract()
        {
            int a = 20;
            int b = 4;
            double result = 16;
            Assert.True(Operator.Substract(a, b) == result);
        }
        //[Fact]
        //[Trait("TestType","NRT")]
        //public void DividingNonIntegerResult()
        //{
        //    int a = 10;
        //    int b = 4;
        //    double result = 2.5;
        //    Assert.True(Operator.Divide(a, b) == result);
        //}

        [Theory(DisplayName ="Prime Number Theory")]
        [Trait("TestType","Theory")]
        [InlineData(0,PrimeNumberInfo.Unknown)]
        public void IsThisNumberPrime(int number,PrimeNumberInfo isPrimeNumber)
        {
            Assert.True(isPrimeNumber == Operator.IsPrimeNumber(number) );
        }
    }
}
