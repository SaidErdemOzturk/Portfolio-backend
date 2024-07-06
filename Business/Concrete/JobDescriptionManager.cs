using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class JobDescriptionManager : IJobDescriptionService
    {
        IJobDescriptionDal _jobDescriptionDal;
        public JobDescriptionManager(IJobDescriptionDal jobDescriptionDal)
        {
            _jobDescriptionDal = jobDescriptionDal;
        }

        public IResult Add(JobDescription jobDescription)
        {
            _jobDescriptionDal.Add(jobDescription);
            return new SuccessResult();
        }

        public IResult Delete(JobDescription jobDescription)
        {
            _jobDescriptionDal.Delete(jobDescription);
            return new SuccessResult();
        }

        public IResult Update(JobDescription jobDescription)
        {
            _jobDescriptionDal.Update(jobDescription);
            return new SuccessResult();
        }
    }
}
