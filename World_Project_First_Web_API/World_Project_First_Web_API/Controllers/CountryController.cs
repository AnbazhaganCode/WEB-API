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
            bool uniqueName = _dbContext.Countries.AsQueryable().Where(x => x.name.ToLower().Trim() == country.name.ToLower().Trim()).Any();
            if(uniqueName)
            {
                return Conflict("Country name should be unique");
            }
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return CreatedAtAction("GetById",new {id=country.id},country);
        }

        [HttpPut ("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<Country> Update(int id,[FromBody] Country country)
        {
            if(id != country.id)
            {
                return BadRequest("Id mismatch");
            }
            var findCountry = _dbContext.Countries.Find(id);
            if(findCountry == null)
            {
                return NotFound("The Id "+ id + " was not found");
            }

            findCountry.name = country.name;
            findCountry.code = country.code;
            findCountry.shortName = country.shortName;

            _dbContext.Countries.Update(findCountry);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Country country = _dbContext.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
