using CarstoreApi.Implementations;
using CarstoreApi.Repositories;
using DominC.Model;
using DominC11;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to. the container.

// ≈⁄œ«œ ŒÌ«—«   ﬂÊÌ‰  Õﬂ„ ›Ì  ’œÌ— «·»Ì«‰«  „‰ Ê≈·Ï  ÿ»Ìﬁﬂ° „⁄ œ⁄„  ‰”Ìﬁ XML
builder.Services.AddControllers(Options =>
{
    Options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//  ”ÃÌ· Œœ„«  «·Ê«ÃÂ… «·⁄«„… ·ﬂ· ‰Ê⁄ „‰ «·ﬂ«∆‰« 
builder.Services.AddScoped<IGenericRepository<Car>, CarRepository>();
builder.Services.AddScoped<IGenericRepository<Sale>, SaleRepository>();
builder.Services.AddScoped<IGenericRepository<Part>, PartRepository>();
builder.Services.AddScoped<IGenericRepository<Supplier>, SupplierRepository>();
builder.Services.AddScoped<IGenericRepository<Customer>, CustomerRepository>();

// ≈⁄œ«œ Œœ„… ﬁ«⁄œ… «·»Ì«‰«  „⁄ «” Œœ«„  SQL Server

builder.Services.AddDbContext<APIContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:CarStoreAPI"]));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Carstore-API-doc.xml"));
    options.AddSecurityDefinition("carstoreapi", new Microsoft.OpenApi.Models.OpenApiSecurityScheme { 
        Type  = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        Description = " please enter the authentication token"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme , 
                Id = "carstoreapi"
            }
        }, new List<string>()
        }        
      });
});

// ≈⁄œ«œ «· Õﬁﬁ „‰ ÂÊÌ… «·„” Œœ„ »«” Œœ«„ JWT Bearer
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        //  ÕœÌœ ≈⁄œ«œ«  «· Õﬁﬁ „‰ ’Õ… —„Ê“ «·Ê’Ê·
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        //  ÕœÌœ «·„⁄·Ê„«  «·’ÕÌÕ… ··„’œ— Ê«·ÃÂ… Ê«·„› «Õ «·”—Ì ·—„Ê“ «·Ê’Ê·
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretKey"]))
    };
});
    builder.Services.AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1 ,0);
        options.ReportApiVersions = true;

    }
    );
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    // «” Œœ«„ Œœ„… «· Õﬁﬁ „‰ ÂÊÌ… «·„” Œœ„
    app.UseAuthentication();
    // «” Œœ«„ Œœ„… «· ›ÊÌ÷
    app.UseAuthorization();
    app.MapControllers();
    // ‘€Ì· «· ÿ»Ìﬁ
    app.Run();
