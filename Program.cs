using ApiRestTest.Services;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; 
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("cnHomeworks"));
builder.Services.AddScoped<IPersonasService,PersonasService>();
builder.Services.AddScoped<IUsuariosService,UsuariosService>();

/*var services = builder.Services;
services.AddCors(options =>  
    {  
          
        options.AddDefaultPolicy(
            policy =>  
            {  
                policy.WithOrigins("https://localhost:7087/api/")
                .WithMethods("GET","POST","PUT", "DELETE") 
                    .AllowAnyHeader();  
            });  
    }); 
*/
builder.Services.AddCors(options =>  
{  
    options.AddPolicy(name: MyAllowSpecificOrigins,  
                      policy  =>  
                      {
                          policy.WithOrigins("https://localhost:4200")
                          .AllowAnyOrigin() .WithMethods("GET","POST"); // add the allowed origins  
                          
                      });  
}); 

var app = builder.Build();
app.UseCors(options => options.AllowAnyOrigin());  
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();