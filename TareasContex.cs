using Microsoft.EntityFrameworkCore;
using ApiRestTest.Models;

public class TareasContext: DbContext
{
    public DbSet<PersonaModel> Personas {get;set;}
    public DbSet<UsuarioModel> Usuarios {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
        List<PersonaModel> personaInit = new  List<PersonaModel>();
        personaInit.Add(new PersonaModel()
        {
            Identificador = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4e5"),Nombres="Juan Eduardo",Apellidos="Torres Lamba",
            Email = "Ja@gmail.com",TipoIdentificacion="CC",FechaCreacion = DateTime.Now,NumerodeIdentificacion = "10908012"
        });
        personaInit.Add(new PersonaModel()
        {
            Identificador = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4e6"),
            Nombres = "Camilo Eduardo",
            Apellidos = "Torres Ferreira",
            Email = "CJa@gmail.com",
            TipoIdentificacion = "CC",
            FechaCreacion = DateTime.Now,
            NumerodeIdentificacion = "10908013"
        });

        modelBuilder.Entity<PersonaModel>(persona =>
        {
            persona.ToTable("Pesrsonas");
            persona.HasKey(p => p.Identificador);
            persona.Property(p => p.Nombres).IsRequired();
            persona.Property(p=>p.Apellidos).IsRequired();
            persona.Property (persona=> persona.Email).IsRequired();
            persona.Property(p=>p.TipoIdentificacion).IsRequired();
            persona.Property(p=>p.NumerodeIdentificacion).IsRequired();
        });

        List<UsuarioModel> userInit = new List<UsuarioModel>();
        userInit.Add(new UsuarioModel()
        {
            Identificador = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4e8"),
            Usuario = "Edu23",
            Pass= "1234",
            FechaCreacion= DateTime.Now
        });
        userInit.Add(new UsuarioModel()
        {
            Identificador = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4e9"),
            Usuario = "Cami32",
            Pass = "1235",
            FechaCreacion = DateTime.Now
        });
        modelBuilder.Entity<UsuarioModel>(usuario =>
        {
            usuario.ToTable("Usuario");
            usuario.HasKey(p => p.Identificador);
            usuario.Property(p =>p.Usuario).IsRequired();
            usuario.Property(p =>p.Pass).IsRequired();
        });
     }
}