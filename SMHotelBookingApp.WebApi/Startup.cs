using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SMHotelBookingApp.Application.ApplicationServices;
using SMHotelBookingApp.Application.Interfaces;
using SMHotelBookingApp.Data_EF.Context;
using SMHotelBookingApp.Data_EF.Interfaces;
using SMHotelBookingApp.Data_EF.TypeRepository;
using SMHotelBookingApp.Data_EF.UnitOfWork;
using SMHotelBookingApp.Domain.DomainModels;
using SMHotelBookingApp.Domain.Interfaces;

namespace SMHotelBookingApp.WebApi
{
    public class Startup
    {
        public Startup(IConfigurationRoot config)
        {
            Configuration = config;
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<SMHotelBookingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddTransient<IGenericRepository<Booking>, GenericRepository<Booking>>();
            services.AddTransient<IGenericRepository<Room>, GenericRepository<Room>>();

            services.AddTransient<IBookingApplicationService, BookingApplicationService>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDbInitializer, DbInitializer>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Initialize the database.
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetService<SMHotelBookingContext>();
                    var dbInitializer = services.GetService<IDbInitializer>();
                    dbInitializer.Initialize(dbContext);
                }
            }
            app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());
        }


    }
}

