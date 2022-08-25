using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SMHotelBookingApp.Application.ApplicationServices;
using SMHotelBookingApp.Application.Interfaces;
using SMHotelBookingApp.Data_EF.Context;
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

        }

        public void Configure(IApplicationBuilder app)
        {
            
            app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
