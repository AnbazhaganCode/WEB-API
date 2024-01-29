using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using World_Project_First_Web_API.Data;
using World_Project_First_Web_API.Models;

namespace World_Project_First_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CountryController(ApplicationDbContext DbContext) 
        {
            _dbContext = DbContext;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult<IEnumerable<Country>> GetAll()
        {
            var countries = _dbContext.Countries.ToList();
            if(countries == null)
            {
                return NoContent();
            }
            return Ok(countries);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult<Country> Get(int id)
        {
            var country = _dbContext.Countries.Find(id);
            if(country == null)
            {
                return NoContent();
            }
            return Ok(country);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        public ActionResult<Country> Create([FromBody] Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return CreatedAtAction("GetById",new {id=country.id},country);
        }

        [HttpPut]
        public ActionResult<Country> Update([FromBody] Country country)
        {
            _dbContext.Countries.Update(country);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            Country country = _dbContext.Countries.Find(id);
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
