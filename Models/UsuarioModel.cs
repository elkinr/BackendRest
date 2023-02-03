namespace ApiRestTest.Models
{
    public class UsuarioModel
    {
       public Guid Identificador {get; set;}
       public string Usuario {get;set;}
       public string Pass {get;set;}
       public DateTime  FechaCreacion {get;set;} 
    }
}