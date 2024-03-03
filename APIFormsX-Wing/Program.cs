using APIFormsX_Wing.Data;
using APIFormsX_Wing.Repositorys;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SystemDBContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database"))
);
/*
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<SystemDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
    );
*/

// Config Repositorys
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPollRepository, PollRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

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
