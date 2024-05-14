using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                SenderCustomer = createCargoDetailDto.SenderCustomer,
                Barcode = createCargoDetailDto.Barcode,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                CargoCompanyId=createCargoDetailDto.CargoCompanyId
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("basarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("basarılı silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                SenderCustomer=updateCargoDetailDto.SenderCustomer,
                Barcode=updateCargoDetailDto.Barcode,
                ReceiverCustomer=updateCargoDetailDto.ReceiverCustomer,
                CargoCompanyId=updateCargoDetailDto.CargoCompanyId,
                CargoDetailId=updateCargoDetailDto.CargoDetailId
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("basarılı");
        }
    }
}
