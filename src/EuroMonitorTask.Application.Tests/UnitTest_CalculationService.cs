using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EuroMonitorTask.Infrastructure.Services;
using EuroMonitorTask.Application.Services;
using EuroMonitorTask.Domain.Models;
using EuroMonitorTask.Domain.Types;
using System.Configuration;

namespace EuroMonitorTask.Application.Tests
{
    [TestClass]
    public class UnitTest_CalculationService
    {
        private int upperLimit = Convert.ToInt32(ConfigurationManager.AppSettings["UpperLimit"]);

        /// <summary>
        /// Testing the conversion of a numeric string to integer using Calculation Service
        /// </summary>
        [TestMethod]
        public void ConversionOfStringToInt()
        {
            ICalculationService calculationService = new CalculationService();

            string input = "3";

            Result result = calculationService.Calculate(input);

            Assert.AreEqual(3, result.Input);
        }

        /// <summary>
        /// Testing Calculation Service with a value smaller than the upper limit.
        /// </summary>
        [TestMethod]
        public void CalculationWithValueSmallerThanUpperLimt()
        {
            ICalculationService calculationService = new CalculationService();

            string input = "2";

            Result result = calculationService.Calculate(input);

            Assert.AreEqual(ResultType.Valid, result.Type);
            Assert.AreEqual(upperLimit - 2, result.Difference);

        }

        /// <summary>
        /// Testing Calculation Service with value equal to upper limit.
        /// </summary>
        [TestMethod]
        public void CalculationWithValueEqualToUpperLimt()
        {
            ICalculationService calculationService = new CalculationService();

            string input = upperLimit.ToString();

            Result result = calculationService.Calculate(input);

            Assert.AreEqual(ResultType.Valid, result.Type);
            Assert.AreEqual(0, result.Difference);

        }

        /// <summary>
        /// Testing Calculation Service with a negative value.
        /// </summary>
        [TestMethod]
        public void CalculationWithNegativeValue()
        {
            ICalculationService calculationService = new CalculationService();

            string input = "-7";

            Result result = calculationService.Calculate(input);

            Assert.AreEqual(ResultType.ValidButNegativeNumber, result.Type);
            Assert.AreEqual(upperLimit - (-7), result.Difference);

        }

        /// <summary>
        /// Testing Calculation Service with value smaller than a 32 bit integer.
        /// </summary>
        [TestMethod]
        public void CalculationWithValueTooSmall()
        {
            ICalculationService calculationService = new CalculationService();

            string input = "-2147483649"; // Int32.MinValue - 1

            Result result = calculationService.Calculate(input);

            Assert.AreEqual(ResultType.NumberTooSmall, result.Type);
        }

        /// <summary>
        /// Testing Calculation Service with value larger than a 32 bit integer.
        /// </summary>
        [TestMethod]
        public void CalculationWithValueTooLarge()
        {
            ICalculationService calculationService = new CalculationService();

            string input = "2147483649"; // Int32.MaxValue + 1

            Result result = calculationService.Calculate(input);

            Assert.AreEqual(ResultType.NumberTooLarge, result.Type);
        }

        /// <summary>
        /// Testing Calculation Service with a non-numeric string.
        /// </summary>
        [TestMethod]
        public void CalculationWithNotANumber()
        {
            ICalculationService calculationService = new CalculationService();

            string input = "12ABC";

            Result result = calculationService.Calculate(input);

            Assert.AreEqual(ResultType.NotANumber, result.Type);
        }
    }
}
