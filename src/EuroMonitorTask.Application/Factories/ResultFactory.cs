using EuroMonitorTask.Domain.Models;
using EuroMonitorTask.Domain.Types;
using EuroMonitorTask.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroMonitorTask.Application.Factories
{
    public class ResultFactory : IResultFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public Result Create(ResultType type, long input)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            int upperLimit = Convert.ToInt32(ConfigurationManager.AppSettings["UpperLimit"]);

            return new Result(type, input, upperLimit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Result Create(ResultType type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            int upperLimit = Convert.ToInt32(ConfigurationManager.AppSettings["UpperLimit"]);

            return new Result(type, upperLimit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="input"></param>
        /// <param name="difference"></param>
        /// <returns></returns>
        public Result Create(ResultType type, long input, int difference)
        {

            if (type == null)
                throw new ArgumentNullException("type");

            int upperLimit = Convert.ToInt32(ConfigurationManager.AppSettings["UpperLimit"]);

            return new Result(type, input, upperLimit, difference);
        }
    }
}
