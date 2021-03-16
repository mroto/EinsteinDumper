using EinsteinDumper.Core.Model.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinDumper.Core.Model.FizzBuzz
{
    public class FizzBuzzValidator : IFizzBuzzValidator
    {
        private const int FizzDivisible = 3;
        private const int BuzzDivisible = 5;

        private readonly ILogger<FizzBuzzValidator> logger;
        private readonly IDivisibleValidator divisibleValidator;

        public FizzBuzzValidator(ILogger<FizzBuzzValidator> logger, IDivisibleValidator divisibleValidator)
        {
            this.logger = logger;
            this.divisibleValidator = divisibleValidator;
        }

        public NumberType GetNumberType(int number)
        {
            this.logger.LogDebug($"Getting number type for:{number}");
            NumberType numberType = NumberType.Number;
            if (this.IsFizz(number))
            {
                numberType = NumberType.Fizz;
                if (this.IsBuzz(number))
                {
                    numberType = NumberType.FizzBuzz;
                }
            }
            else if (this.IsBuzz(number))
            {
                numberType = NumberType.Buzz;
            }
            
            this.logger.LogDebug($"Number type is:{numberType}");
            return numberType;
        }

        private bool IsFizz(int number)
        {
            return this.IsDivisible(number, FizzDivisible);
        }
        private bool IsBuzz(int number)
        {
            return this.IsDivisible(number, BuzzDivisible);
        }

        private bool IsDivisible(int a, int b)
        {
            return this.divisibleValidator.IsDivisible(a, b);
        }
    }
}
