﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobDescriptionService
    {
        IResult Add(JobDescription jobDescription);
        IResult Update(JobDescription jobDescription);
        IResult Delete(JobDescription jobDescription);
    }
}
