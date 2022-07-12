using CarRentalApp.Business.Abstracts;
using CarRentalApp.DataAccess.Abstracts;
using CarRentalApp.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Business.Concretes
{
    public class BrandManager : IBrandService

    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand entity)
        {
            _brandDal.Add(entity);
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public IQueryable<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(x => x.Id == id);
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }
    }
}
