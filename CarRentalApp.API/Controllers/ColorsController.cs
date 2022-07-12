using CarRentalApp.API.Models.Colors;
using CarRentalApp.Business.Abstracts;
using CarRentalApp.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var colors = _colorService.GetAll();
            return Ok(colors);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var color = _colorService.GetById(id);
            if (color != null)
            {
                return Ok(color);
            }
            return BadRequest("Belirttiğiniz ID'ye sahip bir renk bulunamamıştır.");
        }

        [HttpPost]
        public IActionResult Add(VM_Add_Color viewModel)
        {
            Color color = new() { Name = viewModel.Name };
            _colorService.Add(color);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VM_Update_Color viewModel)
        {
            var color = _colorService.GetById(id);
            if (color != null)
            {
                color.Name = viewModel.Name != default ? viewModel.Name : color.Name;
                _colorService.Update(color);
                return Ok();
            }
            return BadRequest("İşlem başarısız!");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var color = _colorService.GetById(id);
            if (color != null)
            {
                _colorService.Delete(color);
                return Ok();
            }
            return BadRequest();
        }
    }
}
