using CarRentalApp.API.Models.Brands;
using CarRentalApp.Business.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrandRentalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var brands = _brandService.GetAll();
            if (brands != null)
                return Ok(brands);
            return BadRequest("Markaları listeme işlemi başarısız!");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var brand = _brandService.GetById(id);
            if (brand != null)
                return Ok(brand);
            return BadRequest("Belirtilen ID'ye uygun marka bulunamadı.");
        }

        [HttpPost]
        public IActionResult Post([FromBody] VM_Create_Brand viewModel)
        {
            _brandService.Add(new()
            {
                Name = viewModel.Name
            });
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VM_Update_Brand viewModel)
        {
            var brand = _brandService.GetById(id);
            if (brand != null)
            {
                brand.Name = viewModel.Name != default ? viewModel.Name : brand.Name;
                // EF Core Transaction mekanizması devrede ise Update komutu olmasa bile güncellemeler gerçekleşecektir.
                _brandService.Update(brand);
                return Ok();
            }
            return BadRequest("Belirtilen ID ile eşleşen marka bulunamadı.");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var brand = _brandService.GetById(id);
            if (brand != null)
            {
                _brandService.Delete(brand);
                return Ok();
            }
            return BadRequest("Belirtilen ID ile eşleşen marka bulunamadı.");
        }
    }
}
