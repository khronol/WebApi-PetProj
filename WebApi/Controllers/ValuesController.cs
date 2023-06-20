using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        Appeal appeal = new Appeal();
        [HttpGet]
        public IEnumerable<IAppeal> Get()
        {
            IEnumerable<IAppeal> temp = appeal.GetAppeal();
            return temp;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Appeal value)
        {
            appeal.AddAppeal(value);
        }
    }
}
