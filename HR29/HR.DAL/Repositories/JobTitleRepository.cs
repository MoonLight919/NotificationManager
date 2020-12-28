using DataFromHrDb.DbLayer;

using Microsoft.EntityFrameworkCore;


namespace HR.DAL.Repositories
{
    public class JobTitleRepository : GenericRepository<JobTitle, int>
    {
        public JobTitleRepository(DbContext context) : base(context)
        {
        }
    }
}
