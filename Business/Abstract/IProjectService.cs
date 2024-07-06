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
    public interface IProjectService
    {
        IDataResult<List<Project>> GetAll();
        IDataResult<List<ProjectWithImageAndTechnologyDto>> GetAllWithDto();
        IDataResult<List<ProjectWithTechnologyDto>> GetMoreProjectDto();
        IDataResult<Project> GetById(int id);
        IResult Add(Project project);
        IResult Update(Project project);
        IResult Delete(Project project);
    }
}
