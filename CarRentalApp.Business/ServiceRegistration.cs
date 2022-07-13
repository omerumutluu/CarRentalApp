using CarRentalApp.Business.Abstracts;
using CarRentalApp.Business.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IBrandService, BrandManager>();
            serviceCollection.AddSingleton<ICarService, CarManager>();
            serviceCollection.AddSingleton<IColorService, ColorManager>();
        }
    }
}
