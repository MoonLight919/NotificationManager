using DataFromHrDb.DbLayer;
using HR.BLL.Models;
using HR.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.Services
{
    public class EmployeeService : GenericService<EmployeeDTO, Employee, int>
    {
        public EmployeeService(IGenericRepository<Employee, int> repository) : base(repository)
        {
        }
    }
}
