using EuroMonitorTask.Application.Factories;
using EuroMonitorTask.Domain.Models;
using EuroMonitorTask.Domain.Types;
using EuroMonitorTask.Infrastructure.Factories;
using EuroMonitorTask.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroMonitorTask.Application.Services
{
    public class CalculationService : ICalculationService
    {

        private IResultFactory messageFactory;

        /// <summary>
        /// 
        /// </summary>
        public CalculationService()
        {
            this.messageFactory = new ResultFactory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Result Calculate(int input)
        {
            int upperLimit = Convert.ToInt32(ConfigurationManager.AppSettings["UpperLimit"]);

            int difference = upperLimit - input;

            return this.messageFactory.Create(
                input < 0 ? ResultType.ValidButNegativeNumber : ResultType.Valid,
                input,
                difference);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Result Calculate(string input)
        {
            int upperLimit = Convert.ToInt32(ConfigurationManager.AppSettings["UpperLimit"]);

            long inputNumber;
            if (!long.TryParse(input, out inputNumber))
                return this.messageFactory.Create(ResultType.NotANumber);

            if (inputNumber > upperLimit || inputNumber > Int32.MaxValue)
                return this.messageFactory.Create(ResultType.NumberTooLarge, inputNumber);

            if (inputNumber < Int32.MinValue)
                return this.messageFactory.Create(ResultType.NumberTooSmall, inputNumber);


            int inputNumberAsInt = Convert.ToInt32(inputNumber);

            return Calculate(inputNumberAsInt);

        }
    }
}

