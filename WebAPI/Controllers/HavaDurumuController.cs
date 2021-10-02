using Entities.Concrete;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RestSharp;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HavaDurumuController:ControllerBase
    {

        private ISehirlerHavaDurumuService _sehirlerHavaDurumuService;
        public HavaDurumuController(ISehirlerHavaDurumuService sehirlerHavaDurumuService)
        {
            _sehirlerHavaDurumuService = sehirlerHavaDurumuService;
        }

        [HttpGet("getweatherall")]
        public async Task<ActionResult> GetWeatherStateAll()
        {
            var result = await _sehirlerHavaDurumuService.GetWeatherAll();
            if (result.Data!=null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getweatherbycity")]
        public async Task<ActionResult> GetWeatherByCity(int cityId)
        {
            if (!cityId.Equals(null))
            {
                var result = await _sehirlerHavaDurumuService.GetWeatherByCity(cityId);
                if (result.Data != null)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
            }
            return BadRequest();
        }

        [HttpGet("getweatherbyregion")]
        public async Task<ActionResult> GetWeatherAllByRegion(int regionId)
        {
            if (!regionId.Equals(null))
            {
                var result = await _sehirlerHavaDurumuService.GetWeatherAllByRegion(regionId);
                if (result.Data != null)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("fetchData")]
        public async Task<IActionResult> FetchData(int type)
        {
            //Type verisi 1 ise veri çekecek 1 den farklı ise sıfırlayacak
            if (type == 1)
            {
                var client = new RestClient("https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                var body = @"";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var resultGenerate = await _sehirlerHavaDurumuService.GenerateSystemBase(response);
                if (resultGenerate.Succeed)
                {
                    return Ok(resultGenerate.Message);
                }
                return BadRequest(resultGenerate.Message);
            }
            var result = _sehirlerHavaDurumuService.Delete();
            if (result.Succeed)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
