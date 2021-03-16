using EinsteinDumper.Infrastructure.FizzBuzz;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EinsteinDumper.Infrastructure.Configuration
{
    public class EinsteinDumperInfrastructureModule
    {
        private readonly IServiceCollection services;

        public EinsteinDumperInfrastructureModule(IServiceCollection services)
        {
            this.services = services;
        }

        public void Configure()
        {
            this.ConfigureFizzBuzz();
        }

        private void ConfigureFizzBuzz()
        {
            this.services.AddTransient(typeof(IFizzBuzzRepository), typeof(FizzBuzzRepository));
        }
    }
}
