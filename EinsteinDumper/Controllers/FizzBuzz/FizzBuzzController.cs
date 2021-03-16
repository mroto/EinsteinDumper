using EinsteinDumper.Core.Model.FizzBuzz;
using EinsteinDumper.Infrastructure.FizzBuzz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinDumper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly ILogger<FizzBuzzController> _logger;
        //private readonly IOptions<FizzBuzzSettings> settings;
        private readonly IFizzBuzzSequenceGenerator fizzBuzzSequenceGenerator;
        private readonly FizzBuzzRepository fizzBuzzRepository;

        public FizzBuzzController(ILogger<FizzBuzzController> logger,
            //IOptions<FizzBuzzSettings> settings,
            IFizzBuzzSequenceGenerator fizzBuzzSequenceGenerator
            )
        {
            _logger = logger;
            //this.settings = settings;
            this.fizzBuzzSequenceGenerator = fizzBuzzSequenceGenerator;
        }

        [HttpGet]
        public IEnumerable<string> Get(int start)
        {
            int max = 1000;
            return fizzBuzzSequenceGenerator.Generate(start, max);
        }
    }
}
