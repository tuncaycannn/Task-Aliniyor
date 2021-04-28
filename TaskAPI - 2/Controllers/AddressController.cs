using TaskAPI.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TaskAPI.Controllers
{
    //Veriler jsona dönüştürülüp, filtrelenmektedir. Veriler default olarak "appsetting.json" içerisinde xml formatında gelmektedir.
    public class AddressController : ControllerBase
    {
        
        private readonly ICityRepository _cityRepository;

        public AddressController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult Index(string from, string shorting)
        {
            if (string.IsNullOrEmpty(from)) { from = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["DefaultData"]; }
            var result = _cityRepository.GetAdress(from, "", "", shorting);
            return Ok(result);
        }

        [HttpGet]
        [Route("[controller]/city/{code}")]
        public IActionResult GetByCityCode(string from, string code, string shorting)
        {
            if (string.IsNullOrEmpty(from)) { from = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["DefaultData"]; }
            var result = _cityRepository.GetAdress(from, "city", code, shorting);
            return Ok(result);
        }

        [HttpGet]
        [Route("[controller]/district/{name}")]
        public IActionResult GetByDistrictName(string from, string name, string shorting)
        {
            if (string.IsNullOrEmpty(from)) { from = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["DefaultData"]; }
            var result = _cityRepository.GetAdress(from, "district", name, shorting);
            return Ok(result);
        }

    }
}
