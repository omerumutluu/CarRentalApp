using CarRentalApp.API.Models.Cars;
using CarRentalApp.Business.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cars = _carService.GetAll().Select(x => new VM_List_Car
            {
                Id = x.Id,
                BrandId = x.BrandId,
                ColorId = x.ColorId,
                DailyPrice = x.DailyPrice,
                Description = x.Description,
                ModelYear = x.ModelYear
            });
            if (cars != null)
            {
                return Ok(cars);
            }
            return BadRequest("Araç listeme işlemi başarısız!");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var car = _carService.GetById(id);
            if (car != null)
            {
                VM_List_Car carViewModel = new VM_List_Car()
                {
                    Id = car.Id,
                    BrandId = car.BrandId,
                    ColorId = car.ColorId,
                    DailyPrice = car.DailyPrice,
                    Description = car.Description,
                    ModelYear = car.ModelYear
                };
                return Ok(carViewModel);
            }
            return BadRequest("Belirtilen ID'ye uygun araç bulunamadı.");
        }

        [HttpPost]
        public IActionResult Post([FromBody] VM_Create_Car viewModel)
        {
            _carService.Add(new()
            {
                BrandId = viewModel.BrandId,
                ColorId = viewModel.ColorId,
                DailyPrice = viewModel.DailyPrice,
                Description = viewModel.Description,
                ModelYear = viewModel.ModelYear,
            });
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VM_Update_Car viewModel)
        {
            var car = _carService.GetById(id);
            if (car != null)
            {
                car.BrandId = viewModel.BrandId != default ? viewModel.BrandId : car.BrandId;
                car.ColorId = viewModel.ColorId != default ? viewModel.ColorId : car.ColorId;
                car.DailyPrice = viewModel.DailyPrice != default ? viewModel.DailyPrice : car.DailyPrice;
                car.Description = viewModel.Description != default ? viewModel.Description : car.Description;
                car.ModelYear = viewModel.ModelYear != default ? viewModel.ModelYear : car.ModelYear;
            }
            // EF Core Transaction mekanizması devrede ise Update komutu olmasa bile güncellemeler gerçekleşecektir.
            _carService.Update(car);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var car = _carService.GetById(id);
            _carService.Delete(car);
            return Ok();
        }
    }
}
