using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto cargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = cargoCustomerDto.Address,
                City = cargoCustomerDto.City,
                District = cargoCustomerDto.District,
                Email = cargoCustomerDto.Email,
                Name = cargoCustomerDto.Name,
                Phone = cargoCustomerDto.Phone,
                Surname = cargoCustomerDto.Surname
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("basarılı");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = updateCargoCustomerDto.Address,
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                City = updateCargoCustomerDto.City,
                District= updateCargoCustomerDto.District,
                Email= updateCargoCustomerDto.Email,
                Name= updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone,
                Surname =updateCargoCustomerDto.Surname
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("basarılı");
        }
    }
}
