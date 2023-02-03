using ApiRestTest.Models;
using ApiRestTest.Services;
using Microsoft.AspNetCore.Mvc;



namespace ApiRestTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Personas : ControllerBase
    {
      
        IPersonasService personaService;
        public Personas(IPersonasService _personaService){
             personaService = _personaService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personaService.GetAll());
        }

       
        [HttpPost]
        public IActionResult Post([FromBody] PersonaModel Persona)
        {
            personaService.save(Persona);
            return Ok();
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] PersonaModel Persona)

        {
            personaService.Update(id, Persona);
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            personaService.Delete(id);
            return Ok();

        }
    }
}
