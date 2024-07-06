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
    public class TechnologyManager : ITechnologyService
    {
        ITechnologyDal _technologyDal;
        public TechnologyManager(ITechnologyDal technologyDal)
        {
            _technologyDal = technologyDal;
        }

        public IResult Add(Technology technology)
        {
            _technologyDal.Add(technology);
            return new SuccessResult();
        }

        public IResult Delete(Technology technology)
        {

            _technologyDal.Delete(technology);
            return new SuccessResult();
        }

        public IResult Update(Technology technology)
        {
            _technologyDal.Update(technology);
            return new SuccessResult();
        }
    }
}
