using EuroMonitorTask.Domain.Models;
using EuroMonitorTask.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroMonitorTask.Infrastructure.Factories
{
    public interface IResultFactory
    {
        /// <summary>
        /// Creates Result
        /// </summary>
        /// <param name="type"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Result Create(ResultType type, long input);

        /// <summary>
        ///  Creates Result
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Result Create(ResultType type);

        /// <summary>
        /// Creates Result
        /// </summary>
        /// <param name="type"></param>
        /// <param name="input"></param>
        /// <param name="difference"></param>
        /// <returns></returns>
        Result Create(Domain.Types.ResultType type, long input, int difference);
    }
}
