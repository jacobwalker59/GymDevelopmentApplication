using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Interfaces;
using API.EmailFolder;
using API.EmailFolder.EmailConcrete;
using API.EmailFolder.EmailInterface;
using API.ExtensionMethods;
using API.IdentityFolder;
using API.Repositories;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
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
            services.AddScoped<ITokenService,TokenService>();
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddDbContext<DataBaseContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DBContext")));
            services.AddScoped<IExerciseRepo,ExerciseRepository>();
            services.AddScoped<ISecondExerciseRepo,SecondExerciseRepository>();
            services.AddScoped(typeof(IGenericRepo<>),(typeof(GenericRepository<>)));
            services.AddAutoMapper(typeof(MappingProfiles));
           
           // really need to have a look at extending the services in the future...

           var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
           services.AddSingleton(emailConfig);
           services.AddScoped<IEmailSender, EmailSender>();

           

           services.AddDbContext<AppIdentityDBContext>(options => 
           {
               options.UseSqlite(Configuration.GetConnectionString("IdentityContext"));

           });
        // i dont think the below does anything...
         services.AddIdentity<AppUser,AppRole>()
          .AddEntityFrameworkStores<AppIdentityDBContext>().AddDefaultTokenProviders();

          services.AddIdentityServices(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
