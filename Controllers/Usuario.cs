using ApiRestTest.Models;
using ApiRestTest.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class Usuario : ControllerBase
    {
        IUsuariosService usuarioservice;
        public Usuario(IUsuariosService _usuarioservice)
        {
            usuarioservice= _usuarioservice;
        }
       
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(usuarioservice.GetAll());
        }

    
       
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioModel usuario)
        {
            usuarioservice.save(usuario);
            return Ok();
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UsuarioModel usuario)
        {
            usuarioservice.Update(id, usuario);
            return Ok();
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            usuarioservice.Delete(id);
            return Ok();
        }
    }
}
