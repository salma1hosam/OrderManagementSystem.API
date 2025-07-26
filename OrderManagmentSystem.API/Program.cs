using Domain.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.API.CustomMiddlewares;
using Persistence.Data;
using Persistence.Repositories;

namespace OrderManagementSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<OrderManagementDbContext>(option =>
            {
                option.UseInMemoryDatabase(builder.Configuration.GetConnectionString("OrderManagementInMemoryDB"));
            });

            builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
            #endregion

            var app = builder.Build();

            #region Configure the HTTP request pipeline.
            app.UseMiddleware<CustomExceptionHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
