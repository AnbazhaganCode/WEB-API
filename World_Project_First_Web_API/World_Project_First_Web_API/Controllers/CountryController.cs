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
        [HttpPost]
        public ActionResult<Country> Create([FromBody] Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
