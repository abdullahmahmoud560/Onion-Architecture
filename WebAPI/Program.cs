using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ إضافة الخدمات هنا قبل Build
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IStudentRepositry, StudentRepositry>();
builder.Services.AddScoped<ISubjectRepositry, SubjectRepository>();
builder.Services.AddScoped<IStudentSubjectRepositry, StudentSubjectRepository>();

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SubjectService>();
builder.Services.AddScoped<StudentSubjectService>();

// ✅ بعد إضافة كل الخدمات
var app = builder.Build();

// ✅ تكوين الـ middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
