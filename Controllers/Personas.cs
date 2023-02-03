using ApiRestTest.Models;
using ApiRestTest.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Personas : ControllerBase
    {
        // GET: api/<Personas>
        IPersonasService personaService;
        public Personas(IPersonasService _personaService){
             personaService = _personaService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personaService.GetAll());
        }

        // POST api/<Personas>
        [HttpPost]
        public IActionResult Post([FromBody] PersonaModel Persona)
        {
            personaService.save(Persona);
            return Ok();
        }

        // PUT api/<Personas>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] PersonaModel Persona)

        {
            personaService.Update(id, Persona);
            return Ok();
        }

        // DELETE api/<Personas>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            personaService.Delete(id);
            return Ok();

        }
    }
}
