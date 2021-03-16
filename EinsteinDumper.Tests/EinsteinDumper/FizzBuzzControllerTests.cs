using EinsteinDumper.Controllers;
using EinsteinDumper.Core.Model.FizzBuzz;
using EinsteinDumper.Core.Model.Util;
using EinsteinDumper.Infrastructure.FizzBuzz;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace EinsteinDumper.Tests
{
    [TestClass]
    public class FizzBuzzControllerTests
    {
        private readonly Mock<ILogger<FizzBuzzController>> fizzBuzzControllerLoggerMock = new Mock<ILogger<FizzBuzzController>>();
        private readonly Mock<ILogger<FizzBuzzSequenceGenerator>> fizzBuzzSequenceGeneratorLoggerMock = new Mock<ILogger<FizzBuzzSequenceGenerator>>();
        private readonly Mock<ILogger<FizzBuzzRepository>> fizzBuzzRepositoryLoggerMock = new Mock<ILogger<FizzBuzzRepository>>();
        private readonly Mock<ILogger<FizzBuzzValidator>> fizzBuzzValidatorLoggerMock = new Mock<ILogger<FizzBuzzValidator>>();

        private FizzBuzzController fizzBuzzController;
        private IFizzBuzzSequenceGenerator fizzBuzzSequenceGenerator;
        private IFizzBuzzRepository fizzBuzzRepository;
        private IFizzBuzzConverter fizzBuzzConverter;
        private IFizzBuzzValidator fizzBuzzValidator;
        private IDivisibleValidator divisibleValidator;

        public FizzBuzzControllerTests()
        {
            this.fizzBuzzRepository = new FizzBuzzRepository(this.fizzBuzzRepositoryLoggerMock.Object);
            this.divisibleValidator = new DivisibleValidator();
            this.fizzBuzzValidator = new FizzBuzzValidator(this.fizzBuzzValidatorLoggerMock.Object, this.divisibleValidator);
            this.fizzBuzzConverter = new FizzBuzzConverter(this.fizzBuzzValidator);
            this.fizzBuzzSequenceGenerator = new FizzBuzzSequenceGenerator(fizzBuzzSequenceGeneratorLoggerMock.Object, this.fizzBuzzConverter, this.fizzBuzzRepository);
            this.fizzBuzzController = new FizzBuzzController(this.fizzBuzzControllerLoggerMock.Object, this.fizzBuzzSequenceGenerator);
        }

        [TestMethod]
        public void Get()
        {
            int start = 1;
            var result = this.fizzBuzzController.Get(start);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GetConcurrent()
        {
            int start = 1;
            int concurrents = 1000;
            IEnumerable<string>[] results = new IEnumerable<string>[concurrents];
            for (int i = 0; i < concurrents; i++)
            {
                results[i] = this.fizzBuzzController.Get(start);
            }

            for (int i = 0; i < concurrents; i++)
            {
                Assert.IsNotNull(results[i]);
            }
        }
    }
}
