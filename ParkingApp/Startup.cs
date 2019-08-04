using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingApp.Data;
using ParkingApp.Domain.Entities;
using ParkingApp.Models;
using ParkingApp.Repositories;

namespace ParkingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ParkingContext>();
            services.AddScoped<IParkingRepository, ParkingRepository>();
            services.AddEntityFrameworkInMemoryDatabase();
            
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                
                cfg.CreateMap<Spot, SpotDto>().ForMember(dest => dest.Id, opts => opts.Condition(src => (src.Id != null)));
                cfg.CreateMap<Spot, SpotUpdateDto>();
                cfg.CreateMap<SpotDto, SpotUpdateDto>();
                cfg.CreateMap<SpotUpdateDto, SpotDto>();
                cfg.CreateMap<SpotDto, Spot>().ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != null));
                cfg.CreateMap<SpotUpdateDto, Spot>().ForMember(x => x.Id, opt => opt.Ignore());



                cfg.CreateMap<BookingDto, Booking>().ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != null));
                cfg.CreateMap<BookingUpdateDto, BookingDto>().ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<BookingUpdateDto, Booking>().ForMember(x => x.Id, opt => opt.Ignore());
                cfg.CreateMap<Booking, BookingDto>().ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != null ));

            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
