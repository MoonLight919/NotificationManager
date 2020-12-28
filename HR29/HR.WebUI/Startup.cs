
using HR.BLL.Modules;
using HR.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.WebUI
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        //--------------------------------------------------------
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEmployeeService(Configuration);
            //services.AddDbContext<HrContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("HrConnection")));
            //// Transient – на каждое требование контейнер создает новый экземпляр сервиса
            ////services.AddTransient<DbContext, HrContext>();
            //// Scoped – сервис создается один раз на запрос
            //services.AddScoped<DbContext, HrContext>();
            //// Singleton – сервис один на все приложение
            ////JobTitleRepository : GenericRepository<JobTitle>
            //services.AddTransient<IGenericRepository<JobTitle>, JobTitleRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "Default",
                        template: "{controller=jobtitle}/{action=index}"
                    );
            });

        }
    }
}
