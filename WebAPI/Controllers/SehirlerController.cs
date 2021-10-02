using Business.Abstract;
using Business.Requests;

using Entities.Concrete;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

using RestSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirlerController : ControllerBase
    {

        private ISehirlerService _sehirlerService;
        private ISehirlerHavaDurumuService _sehirlerHavaDurumuService;
        public SehirlerController(ISehirlerService sehirlerService, ISehirlerHavaDurumuService sehirlerHavaDurumuService)
        {
            _sehirlerService = sehirlerService;
            _sehirlerHavaDurumuService = sehirlerHavaDurumuService;
        }

        [HttpGet("getcities")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sehirlerService.GetList();
            if (result.Data!=null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("getcitiesById")]
        public async Task<IActionResult> GetCitiesById(int sehirId)
        {
            var result = await _sehirlerService.GetCityById(sehirId);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("fetchData")]
        public async Task<IActionResult> FetchData(int type)
        {
            //Type verisi 1 ise veri çekecek 1 den farklı ise sıfırlayacak
            if (type==1)
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
