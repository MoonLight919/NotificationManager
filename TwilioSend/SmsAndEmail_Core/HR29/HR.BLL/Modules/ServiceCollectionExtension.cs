using DataFromHrDb.DbLayer;
using HR.BLL.Models;
using HR.BLL.Services;
using HR.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.Modules
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEmployeeService(this IServiceCollection services,
            IConfigurationRoot Configuration)
        {

            services.AddDbContext<HrContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HrConnection")));
            // Transient – на каждое требование контейнер создает новый экземпляр сервиса
            //services.AddTransient<DbContext, HrContext>();
            // Scoped – сервис создается один раз на запрос
            services.AddScoped<DbContext, HrContext>();
            // Singleton – сервис один на все приложение
            //JobTitleRepository : GenericRepository<JobTitle>
            services.AddTransient<IGenericRepository<JobTitle, int>, JobTitleRepository>();
            services.AddTransient<IGenericRepository<Employee, int>, EmployeeRepository>();
            services.AddTransient<IGenericRepository<Test, Guid>, TestRepository>();


            services.AddTransient<IGenericService<EmployeeDTO, int>, EmployeeService>();
            services.AddTransient<IGenericService<JobTitleDTO, int>, JobTitleService>();
            services.AddTransient<IGenericService<TestDTO, Guid>, TestService>();
            return services;
        }
    }
}
