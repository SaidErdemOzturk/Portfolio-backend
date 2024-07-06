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
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;
        ITechnologyService _technologyService;
        public ProjectManager(IProjectDal projectDal, ITechnologyService technologyService)
        {
            _projectDal = projectDal;
            _technologyService = technologyService;
        }

        public IResult Add(Project project )
        {
            _projectDal.Add(project);
            return new SuccessResult();
        }

        public IResult Delete(Project project)
        {
            _projectDal.Delete(project);
            return new SuccessResult();
        }

        public IDataResult<List<Project>> GetAll()
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll());
        }

        public IDataResult<List<ProjectWithImageAndTechnologyDto>> GetAllWithDto()
        {
            return new SuccessDataResult<List<ProjectWithImageAndTechnologyDto>>(_projectDal.GetProjectsWithImageAndTechnology());
        }

        public IDataResult<Project> GetById(int id)
        {
            return new SuccessDataResult<Project>(_projectDal.Get(p=>p.Id==id));
        }

        public IDataResult<List<ProjectWithTechnologyDto>> GetMoreProjectDto()
        {
            return new SuccessDataResult<List<ProjectWithTechnologyDto>>(_projectDal.GetMoreProjectDto());
        }

        public IResult Update(Project project)
        {
            _projectDal.Update(project);
            return new SuccessResult();
        }
    }
}
