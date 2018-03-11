using ecard.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ecard
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
            services.AddMvc();

            //WOWOCO LET MVC SERVICES KNOW ABOUT MY DATABASE
            //inject 
            //services.AddDbContext<DbBridge>(options => options.UseSqlite(Configuration["MyDB"])); CONNECTION STRING IS THE PATH TO WHERE THE PHYSICAL DB WILL BE
            services.AddDbContext<DbBridge>(options => options.UseSqlite(Configuration["MyDB"]));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
            //WOWOCO: CODE BLOCK TO AUTO-CREATE THE DATABASE WHEN NEEDED IF THERE IS NOT ONE ALREADY
            using (var serviceScope = app
                .ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                serviceScope
                    .ServiceProvider
                    .GetService<DbBridge>()
                    .Database
                    .EnsureCreated();

            }


        }
    }
}
