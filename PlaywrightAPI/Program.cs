using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policy => {

    policy.AddPolicy("Policy_Name", builder =>
      builder.WithOrigins("https://*:7112/")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyOrigin()
 );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Configure the HTTP request pipeline.
app.UseCors("Policy_Name");

app.MapControllers();



app.Run();
