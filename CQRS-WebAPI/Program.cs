
using CQRS_BLL.CQRS.Handlers.CommandHandlers;
using CQRS_BLL.CQRS.Handlers.QueryHandlers;
using CQRS_DAL;
using CQRS_DAL.Repositories;
using CQRS_DAL.Repositories.Abstract;

namespace CQRS_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DbContexts
            builder.Services.AddDbContext<AppCommandDbContext>();
            builder.Services.AddScoped<AppQueryDbContext>();

            //Repositories
            builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();

            //Command-Query Handlers
            builder.Services.AddTransient<CreateProductCommandHandler>();
            builder.Services.AddTransient<DeleteProductCommandHandler>();
            builder.Services.AddTransient<GetProductsQueryHandler>();
            builder.Services.AddTransient<GetProductByIdQueryHandler>();

            builder.Services.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly);
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


            app.MapControllers();

            app.Run();
        }
    }
}
