using ApiRestTest.Controllers;
using ApiRestTest.Models;
namespace ApiRestTest.Services
{
    public class PersonasService: IPersonasService
    {
        TareasContext context;
       public PersonasService(TareasContext DbContex) { 
            context = DbContex;
       }

      public IEnumerable<PersonaModel> GetAll()
        {
            return context.Personas;
        }

      public async Task save(PersonaModel persona)
      {
        context.Personas.Add(persona);
        await context.SaveChangesAsync();
      }
      
      public async Task Update(Guid id, PersonaModel persona)
      {
            var personaactual = context.Personas.Find(id);
            if (personaactual != null)
            {
                personaactual.Nombres = persona.Nombres;
                personaactual.Apellidos= persona.Apellidos;
                personaactual.NumerodeIdentificacion = persona.NumerodeIdentificacion;
                personaactual.Email= persona.Email;
                personaactual.TipoIdentificacion = persona.TipoIdentificacion;
                personaactual.FechaCreacion= persona.FechaCreacion;

                await context.SaveChangesAsync();
            }
       }

       public async Task Delete(Guid id)
       {
            var personaactual = context.Personas.Find(id);
            if (personaactual != null)
            {
                context.Personas.Remove(personaactual);
                await context.SaveChangesAsync();
            }
        }

    }

    public interface IPersonasService
    {
        IEnumerable<PersonaModel> GetAll();
        Task save(PersonaModel persona);
        Task Update(Guid id, PersonaModel persona);
        Task Delete(Guid id);
    }
}
