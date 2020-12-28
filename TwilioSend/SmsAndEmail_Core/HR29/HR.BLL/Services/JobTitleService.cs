using DataFromHrDb.DbLayer;
using HR.BLL.Models;
using HR.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.Services
{
    public class JobTitleService : GenericService<JobTitleDTO, JobTitle, int>
    {
        public JobTitleService(IGenericRepository<JobTitle, int> repository) : base(repository)
        {
        }
    }
}
