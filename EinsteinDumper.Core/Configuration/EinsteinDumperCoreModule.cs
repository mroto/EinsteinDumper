
using EinsteinDumper.Core.Model;
using EinsteinDumper.Core.Model.FizzBuzz;
using EinsteinDumper.Core.Model.Util;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EinsteinDumper.Configuration
{
    public class EinsteinDumperCoreModule
    {

        private readonly IServiceCollection services;

        public EinsteinDumperCoreModule(IServiceCollection services)
        {
            this.services = services;
        }

        public void Configure()
        {
            this.ConfigureFizzFuzz();
        }

        private void ConfigureFizzFuzz()
        {
            this.services.AddTransient(typeof(IFizzBuzzSequenceGenerator), typeof(FizzBuzzSequenceGenerator));
            this.services.AddTransient(typeof(IFizzBuzzConverter), typeof(FizzBuzzConverter));
            this.services.AddTransient(typeof(IFizzBuzzValidator), typeof(FizzBuzzValidator));
            this.services.AddTransient(typeof(IDivisibleValidator), typeof(DivisibleValidator));
        }
    }
}
