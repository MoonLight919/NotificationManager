using DataFromHrDb.DbLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.DAL.Repositories
{
    public class TestRepository : GenericRepository<Test, Guid>
    {
        public TestRepository(DbContext context) : base(context)
        {
        }
    }
}
