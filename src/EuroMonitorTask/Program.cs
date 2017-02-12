using EuroMonitorTask.Application.Services;
using EuroMonitorTask.Domain.Models;
using EuroMonitorTask.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroMonitorTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICalculationService calculationService = new CalculationService();

            bool repeat = true;

            while (repeat)
            {

                Console.Write("Enter a number equal or smaller than {0} (Enter 'q' to quit): ", ConfigurationManager.AppSettings["UpperLimit"]);

                string input = Console.ReadLine().ToLower();
                if (input.Equals("q"))
                    Environment.Exit(0);

                Result result = calculationService.Calculate(input);

                Console.WriteLine(result.ToString());

            }
        }
    }
}
