using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EuroMonitorTask.Infrastructure.Services;
using EuroMonitorTask.Application.Services;
using EuroMonitorTask.Domain.Models;
using EuroMonitorTask.Domain.Types;
using System.Configuration;
using EuroMonitorTask.Infrastructure.Factories;
using EuroMonitorTask.Application.Factories;

namespace EuroMonitorTask.Application.Tests
{
    [TestClass]
    public class UnitTest_ResultFactory
    {
        private int upperLimit = Convert.ToInt32(ConfigurationManager.AppSettings["UpperLimit"]);

        /// <summary>
        /// Testing Result Factory with a NotANumber state.
        /// </summary>
        [TestMethod]
        public void NotANumber()
        {
            IResultFactory resultFactory = new ResultFactory();

            Result result = resultFactory.Create(ResultType.NotANumber);

            Assert.AreEqual(0, result.Input);
            Assert.AreEqual(0, result.Difference);
            Assert.AreEqual(ResultType.NotANumber, result.Type);
        }


        /// <summary>
        /// Testing Result Factory with a NumberTooLarge state.
        /// </summary>
        [TestMethod]
        public void NumberTooLarge()
        {
            IResultFactory resultFactory = new ResultFactory();

            int max = (int)(Int32.MaxValue);
            long input = max + 1;

            Result result = resultFactory.Create(ResultType.NumberTooLarge, input);

            Assert.AreEqual(input, result.Input);
            Assert.AreEqual(0, result.Difference);
            Assert.AreEqual(ResultType.NumberTooLarge, result.Type);
        }

        /// <summary>
        /// Testing Result Factory with a NumberTooSmall state.
        /// </summary>
        [TestMethod]
        public void NumberTooSmall()
        {
            IResultFactory resultFactory = new ResultFactory();

            int min = (int)(Int32.MinValue);
            long input = min - 1;

            Result result = resultFactory.Create(ResultType.NumberTooSmall, input);

            Assert.AreEqual(input, result.Input);
            Assert.AreEqual(0, result.Difference);
            Assert.AreEqual(ResultType.NumberTooSmall, result.Type);
        }


        /// <summary>
        /// Testing Result Factory with a Valid state.
        /// </summary>
        [TestMethod]
        public void Valid()
        {
            IResultFactory resultFactory = new ResultFactory();

            long input = 3;
            int difference = 2;

            Result result = resultFactory.Create(ResultType.Valid, input, difference);

            Assert.AreEqual(input, result.Input);
            Assert.AreEqual(difference, result.Difference);
            Assert.AreEqual(ResultType.Valid, result.Type);
        }

        /// <summary>
        /// Testing Result Factory with a ValidButNegativeNumber state.
        /// </summary>
        [TestMethod]
        public void ValidButNegativeNumber()
        {
            IResultFactory resultFactory = new ResultFactory();

            long input = -1;
            int difference = 6;

            Result result = resultFactory.Create(ResultType.ValidButNegativeNumber, input, difference);

            Assert.AreEqual(input, result.Input);
            Assert.AreEqual(difference, result.Difference);
            Assert.AreEqual(ResultType.ValidButNegativeNumber, result.Type);
        }

    }
}
