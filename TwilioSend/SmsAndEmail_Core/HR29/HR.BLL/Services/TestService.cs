using DataFromHrDb.DbLayer;
using HR.BLL.Models;
using HR.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.Services
{
    public class TestService : GenericService<TestDTO, Test, Guid>
    {
        public TestService(IGenericRepository<Test, Guid> repository) : base(repository)
        {
        }
    }
}
