using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITechnologyService
    {
        IResult Add(Technology technology);
        IResult Update(Technology technology);
        IResult Delete(Technology technology);
    }
}
