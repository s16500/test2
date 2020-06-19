using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Test.Exceptions;
using WebAPI_Test.Models;
using WebAPI_Test.Services;

namespace WebAPI_Test.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IAPBDDbService _dbService;

        public PetsController(IAPBDDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{year=year}")]
        public async Task<IActionResult> GetPets(string year) {
            try
            {
                var result = await _dbService.GetPets(year);
                return Ok(result);
            }
            catch (NoRecordsExistException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPet([FromBody]POJO data)
        {
            try
            {
                await _dbService.AddPet(data);
                return Ok();
            }
            catch (RecordCanNotBeInserted ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}