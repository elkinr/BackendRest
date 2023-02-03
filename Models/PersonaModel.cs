namespace ApiRestTest.Models
{
public class PersonaModel
    {
    public Guid Identificador {get; set;}
    public string Nombres {get;set;}
    public string Apellidos {get;set;}
    public string NumerodeIdentificacion {get;set;}
    public string Email {get;set;}
    public string TipoIdentificacion {get;set;}
    public DateTime  FechaCreacion {get;set;}
    }
}