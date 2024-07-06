using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobService
    {
        IDataResult<List<JobWithDescriptionDto>> GetJobsWithDescriptionDto();
        IResult Add(Job job);
        IResult Update(Job job);
        IResult Delete(Job job);
    }
}
