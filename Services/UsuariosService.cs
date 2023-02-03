using ApiRestTest.Models;
namespace ApiRestTest.Services
{
    public class UsuariosService: IUsuariosService
    {
       TareasContext _context;
       
        public UsuariosService(TareasContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            return _context.Usuarios;
        }

        public async Task save(UsuarioModel usuario)
        {
           _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, UsuarioModel usuario)
        {
            var usuarioactual = _context.Usuarios.Find(id);
            if (usuarioactual != null)
            {
                usuarioactual.Usuario = usuario.Usuario;
                usuarioactual.Pass = usuario.Pass;
                usuarioactual.FechaCreacion = usuario.FechaCreacion;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var usuarioactual = _context.Usuarios.Find(id);
            if (usuarioactual != null)
            {
                _context.Remove(usuarioactual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IUsuariosService
    {
         IEnumerable<UsuarioModel> GetAll();
         Task save(UsuarioModel usuario);
         Task Update(Guid id, UsuarioModel usuario);
         Task Delete(Guid id);
    }
}
