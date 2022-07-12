using CarRentalApp.DataAccess.Abstracts;
using CarRentalApp.DataAccess.Context;
using CarRentalApp.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.DataAccess.Concretes.EntityFrameworkCore
{
    public class EfBrandRepository : EfGenericRepository<Brand>, IBrandDal
    {
        public EfBrandRepository(CarRentalDbContext context) : base(context)
        {
        }
    }
}
