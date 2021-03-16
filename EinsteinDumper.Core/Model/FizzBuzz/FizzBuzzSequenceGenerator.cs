
using EinsteinDumper.Infrastructure.FizzBuzz;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EinsteinDumper.Core.Model.FizzBuzz
{
    public class FizzBuzzSequenceGenerator : IFizzBuzzSequenceGenerator
    {
        private readonly ILogger<FizzBuzzSequenceGenerator> logger;
        private readonly IFizzBuzzConverter fizzBuzzConverter;
        private readonly IFizzBuzzRepository fizzBuzzRepository;

        public FizzBuzzSequenceGenerator(ILogger<FizzBuzzSequenceGenerator> logger,
            IFizzBuzzConverter fizzBuzzConverter,
            IFizzBuzzRepository fizzBuzzRepository)
        {
            this.logger = logger;
            this.fizzBuzzConverter = fizzBuzzConverter;
            this.fizzBuzzRepository = fizzBuzzRepository;
        }

        public IEnumerable<string> Generate(int start, int max)
        {
            this.logger.LogDebug($"Generate start={start}, max={max}");
            int current = start;
            while (current <= max)
            {
                this.logger.LogDebug($"Generating number:{current}");
                var number = this.fizzBuzzConverter.Convert(current);
                this.fizzBuzzRepository.Add(number);
                yield return number;
                current++;
            }
        }
    }
}
