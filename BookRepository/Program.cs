using BookRepository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<BookRepoDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BookConn"))
);

builder.Services.AddScoped<IBookData, SqlData>();

// builder.Services.AddApiVersioning(opt =>
// {
//     opt.DefaultApiVersion = new ApiVersion(1, 1);
//     opt.AssumeDefaultVersionWhenUnspecified = true;
//     opt.ReportApiVersions = true;
//     // opt.ApiVersionReader = new QueryStringApiVersionReader("v");
//     // opt.ApiVersionReader = new HeaderApiVersionReader("x-version");

//     opt.ApiVersionReader = ApiVersionReader.Combine(
//         new QueryStringApiVersionReader("version",  "ver",  "v"),
//         new HeaderApiVersionReader("x-version")
//     );
// });

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 1);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = new UrlSegmentApiVersionReader();
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
