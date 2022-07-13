using CarRentalApp.DataAccess.Abstracts;
using CarRentalApp.DataAccess.Concretes.EntityFrameworkCore;
using CarRentalApp.DataAccess.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddDbContext<CarRentalDbContext>(ServiceLifetime.Singleton);

            serviceDescriptors.AddSingleton<IBrandDal, EfBrandRepository>();
            serviceDescriptors.AddSingleton<ICarDal, EfCarRepository>();
            serviceDescriptors.AddSingleton<IColorDal, EfColorRepository>();
        }
    }
}
