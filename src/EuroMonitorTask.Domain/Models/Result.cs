using EuroMonitorTask.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroMonitorTask.Domain.Models
{
    public class Result
    {
        public ResultType Type { get; private set; }
        public long Input { get; private set; }
        public int Difference { get; private set; }

        private int upperLimit = 0;

        private Result() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="input"></param>
        /// <param name="upperLimit"></param>
        /// <param name="difference"></param>
        public Result(ResultType type, long input, int upperLimit, int difference)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            this.Type = type;
            this.Input = input;
            this.upperLimit = upperLimit;
            this.Difference = difference;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="input"></param>
        /// <param name="upperLimit"></param>
        public Result(ResultType type, long input, int upperLimit)
        {
            this.Type = type;
            this.Input = input;
            this.upperLimit = upperLimit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="upperLimit"></param>
        public Result(ResultType type, int upperLimit)
        {
            this.Type = type;
            this.upperLimit = upperLimit;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns>Message to display to user</returns>
        public override string ToString()
        {
            switch (this.Type)
            {
                case ResultType.NotANumber:
                    return string.Format("You have not entered a valid number. Please enter any whole number equal or smaller than {0}.", this.upperLimit);
                case ResultType.NumberTooLarge:
                    return string.Format("You have entered a number larger than {0}. Please enter any whole number equal or smaller than {0}.", this.upperLimit);
                case ResultType.ValidButNegativeNumber:
                case ResultType.Valid:
                    return string.Format("The number required to get to {0} is {1}", this.upperLimit, this.Difference);
                default:
                    return string.Format("Invalid message type.");
            }

        }

    }
}
