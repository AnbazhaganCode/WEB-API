using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using World_Project_First_Web_API.Data;

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
        public ActionResult<IEnumerable<Country>> GetAll()
        {
            return _dbContext.Countries.ToList();
        }
        
        [HttpGet("{id:int}")]
        public ActionResult<Country> Get(int id)
        {
            return _dbContext.Countries.Find(id);
        }
        
        [HttpPost]
        public ActionResult<Country> Create([FromBody] Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return Ok();
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
