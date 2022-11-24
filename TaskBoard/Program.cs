using TaskBoard.DataAccess;
using TaskBoard.Filters;
using TaskBoard.Services;

namespace CustomBoard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers(option => option.Filters.Add<ServicesExceptionsFilterAttribute>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IBoardRepository, ListBoardRepository>();
            builder.Services.AddSingleton<IBoardService, BoardService>();
            builder.Services.AddSingleton<ITaskService, TaskService>();
            builder.Services.AddSingleton<ITaskRepository, ListTaskRepository>();
            //builder.Services.AddScoped<ServicesExceptionsFilterAttribute>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}