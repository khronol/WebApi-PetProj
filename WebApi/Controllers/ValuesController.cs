using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IEnumerable<IAppeal> Get()
        {
            return AppealDbContext.;
        }


        // GET api/values/5
        public IAppeal GetCarById(int id)
        {
            return AppealDbContext.GetContactById(id);
        }



        [HttpGet]
        [Route("GetRange/{pos}/count/{count}")]
        public IEnumerable<IAppeal> Get(int pos, int count, int agrs = 0)
        {
            return AppealDbContext.GetContactRange(pos, count);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] IAppeal value)
        {
            AppealDbContext.AddCar(value);
        }
    }
}
