using DataFromHrDb.DbLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee, int>
    {
        public EmployeeRepository(DbContext context) : base(context)
        {
        }
    }
}
