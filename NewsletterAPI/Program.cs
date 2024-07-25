using NewsletterAPI.Data;
using NewsletterAPI.Interfaces;
using NewsletterAPI.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<NewsletterDbContext>();
builder.Services.AddScoped<ISmsMessageRepository, SmsMessageRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
