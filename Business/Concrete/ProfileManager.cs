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
    public class ProfileManager : IProfileService
    {
        IProfileDal _profileDal;
        public ProfileManager(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }

        public IDataResult<Profile> GetProfile()
        {
            return new SuccessDataResult<Profile>(_profileDal.GetAll().First());
        }

        public IResult Update(Profile profile)
        {
            _profileDal.Update(profile);
            return new SuccessResult();
        }
    }
}
