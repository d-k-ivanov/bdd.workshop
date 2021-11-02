using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace bdd.workshop.calculator.test.selenium
{
    public class CalculatorTests : IDisposable
    {
        IWebDriver driver = new ChromeDriver("C:\\CommonExePath\\");

        public void Dispose()
        {
            driver.Close();
        }
        private void EvaluateOperation(int a, int b, string operation, double result)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var aXpath = "//input[@id='A']";
            var bXpath = "//input[@id='B']";
            var cmdXpath = "//input[@id='Command']";
            var submitButton = "//input[@type='submit']";
            driver.Url = "https://bdd-workshop-the-calculator.azurewebsites.net/Calculator";
            var inputA = FindElement(aXpath, wait);
            var inputCmd = FindElement(cmdXpath, wait);
            var inputB = FindElement(bXpath, wait);
            var button = FindElement(submitButton, wait);
            inputA.SendKeys(a.ToString());
            inputCmd.SendKeys(operation);
            inputB.SendKeys(b.ToString());
            button.Click();
            var theResult = "//td[@id='theResult']";
            var outputResultString = FindElement(theResult, wait).Text;
            Assert.True(double.TryParse(outputResultString, out double outputResult));
            Assert.True(result == outputResult);
        }
        IWebElement FindElement(string xpath, WebDriverWait wait)
        {
            wait.Until(driver => driver.FindElement(By.XPath(xpath)));
            return driver.FindElement(By.XPath(xpath));
        }

        [Fact]
        [Trait("TestType", "FT")]
        public void BasicAdd()
        {
            int a = 1;
            int b = 2;
            double result = 3;
            string operation = "+";
            EvaluateOperation(a, b, operation, result);
        }
        [Fact]
        [Trait("TestType", "FT")]
        public void BasicMultiply()
        {
            int a = 10;
            int b = 4;
            double result = 40;
            string operation = "x";
            EvaluateOperation(a, b, operation, result);
        }
        [Fact]
        [Trait("TestType", "FT")]
        public void BasicDivide()
        {
            int a = 20;
            int b = 4;
            double result = 5;
            string operation = "/";
            EvaluateOperation(a, b, operation, result);
        }

        [Fact]
        [Trait("TestType", "FT")]
        public void BasicSubstract()
        {
            int a = 20;
            int b = 4;
            double result = 16;
            string operation = "-";
            EvaluateOperation(a, b, operation, result);
        }
        [Fact]
        [Trait("TestType", "FT")]
        public void DividingNonIntegerResult()
        {
            int a = 10;
            int b = 4;
            double result = 2.5;
            string operation = "/";
            EvaluateOperation(a, b, operation, result);
        }
    }
}