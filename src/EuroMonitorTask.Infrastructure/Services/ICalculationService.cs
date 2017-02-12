using EuroMonitorTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroMonitorTask.Infrastructure.Services
{
    public interface ICalculationService
    {
        /// <summary>
        /// Calculates value required to reach upper limit.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        Result Calculate(int number);

        /// <summary>
        /// Calculates value required to reach upper limit.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Result Calculate(string input);
    }
}
