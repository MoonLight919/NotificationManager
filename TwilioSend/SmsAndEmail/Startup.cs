using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SmsAndEmail.Models;

namespace SmsAndEmail
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
            services.Configure<MailSetup>(Configuration.GetSection("MailSetup"));
            services.Configure<SmsSetup>(Configuration.GetSection("SmsSetup"));
            services.AddTransient<IMessage, SMSService>();
            services.AddTransient<IEmailMessage, EmailService>();
            services.AddCors(options =>
            {
                options.AddPolicy("policy1", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("policy1");
            app.UseMvc();
        }
    }
}
