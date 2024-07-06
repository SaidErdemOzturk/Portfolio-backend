using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfJobDal : EfEntityRepositoryBase<Job, PortfolioContext>, IJobDal
    {
        public List<JobWithDescriptionDto> GetJobsWithDescriptionDto()
        {
            using (var context = new PortfolioContext())
            {
                var result = from j in context.Jobs
                             select new JobWithDescriptionDto
                             {
                                 JobId = j.Id,
                                 Descriptions = (from description in context.JobDescriptions
                                                 where j.Id == description.JobId
                                                 select description).ToList(),
                                 EndedDate = j.EndedDate,
                                 StartedDate = j.StartedDate,
                                 Tab = j.Tab,
                                 Title = j.Title,
                             };
                                             
                return result.ToList();
            }
        }
    }
}
