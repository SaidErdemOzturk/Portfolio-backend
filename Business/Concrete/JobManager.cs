using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class JobManager : IJobService
    {
        IJobDal _jobDal;
        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public IResult Add(Job job)
        {
            _jobDal.Add(job);
            return new SuccessResult();
        }

        public IResult Delete(Job job)
        {
            _jobDal.Delete(job);
            return new SuccessResult();
        }

        public IDataResult<List<JobWithDescriptionDto>> GetJobsWithDescriptionDto()
        {

            return new SuccessDataResult<List<JobWithDescriptionDto>>(_jobDal.GetJobsWithDescriptionDto());
        }

        public IResult Update(Job job)
        {
            _jobDal.Update(job);
            return new SuccessResult();
        }
    }
}
