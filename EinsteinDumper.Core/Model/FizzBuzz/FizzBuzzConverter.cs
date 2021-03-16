using EinsteinDumper.Core.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinDumper.Core.Model.FizzBuzz
{
    public class FizzBuzzConverter : IFizzBuzzConverter
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private const string FizzBuzz = "FizzBuzz";

        private readonly IFizzBuzzValidator fizzBuzzValidator;

        public FizzBuzzConverter(IFizzBuzzValidator fizzBuzzValidator)
        {
            this.fizzBuzzValidator = fizzBuzzValidator;
        }

        public string Convert(int number)
        {
            var numberType = this.fizzBuzzValidator.GetNumberType(number);
            switch (numberType)
            {
                case NumberType.Fizz:
                    return Fizz;
                case NumberType.Buzz:
                    return Buzz;
                case NumberType.FizzBuzz:
                    return FizzBuzz;
                default:
                    return number.ToString();
            }
        }
    }
}
