using Matala1_ASP.BL;
using Microsoft.AspNetCore.Mvc;

namespace Matala1_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        // GET: api/<CastController>
        [HttpGet]
        public IEnumerable<Cast> Get()
        {
            return Cast.Read();
        }

        // GET api/<CastController>/5
        [HttpGet("{id}")]
        public Cast? Get(string id)
        {
            return Cast.Read().FirstOrDefault(c => c.Id == id);
        }

        // POST api/<CastController>
        [HttpPost]
        public bool Post([FromBody] Cast cast)
        {
            return Cast.Insert(cast);
        }

        // PUT api/<CastController>/5
        [HttpPut("{id}")]
        public bool Put(string id, [FromBody] Cast updatedCast)
        {
            var existingCast = Cast.Read().FirstOrDefault(c => c.Id == id);
            if (existingCast == null) return false;

            existingCast.Name = updatedCast.Name;
            existingCast.Role = updatedCast.Role;
            existingCast.Date = updatedCast.Date;
            existingCast.Country = updatedCast.Country;

            return true;
        }

        // DELETE api/<CastController>/5
        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            var castToDelete = Cast.Read().FirstOrDefault(c => c.Id == id);
            if (castToDelete == null) return false;

            Cast.Read().Remove(castToDelete);
            return true;
        }
    }
}
