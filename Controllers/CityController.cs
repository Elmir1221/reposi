using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Cities;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Xml.Linq;

namespace Apitask.Controllers
{

    public class CityController : BaseController
    {
        private readonly ICityService _cityservice;
        public CityController(ICityService cityService)
        {
            _cityservice = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cityservice.GetAllAsync());
        }
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _cityservice.GetByIdAsync(id));

        }
        [HttpGet]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            return Ok(await _cityservice.GetByNameAsync(name));

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityCreateDto request)
        {
            try
            {
                await _cityservice.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data successfully created" } ); 
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
