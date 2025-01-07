using Api.Hubs;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules.BookingValidations;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DtoLayer.BookingDto;
using FluentValidation;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", builder => {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
builder.Services.AddSignalR();


builder.Services.AddDbContext<Context>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.ContainerDependencies(); // Extension sýnýfýmýz

builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>(); // Validasyon için registration iþlemi

//Cycle Was Detected Hatasýnýn çözümü
//Basket için Include metodu kullanmýþtýk ürün adýna ulaþmak için alt alta bir yapý olarak gelmesi gerekiyordu ama hata alýyorduk bu kod ile istediðimiz yapýya ulaþýyoruz.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = 
    ReferenceHandler.IgnoreCycles);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.MapHub<SignalRHub>("/signalrhub");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
