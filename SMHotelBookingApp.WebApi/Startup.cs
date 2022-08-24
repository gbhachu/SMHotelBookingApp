using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SMHotelBookingApp.Data_EF.Context;

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

        }

        public void Configure(IApplicationBuilder app)
        {
            
            app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
