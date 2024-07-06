using Core.DataAccess.EntityFramework;
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
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProjectDal : EfEntityRepositoryBase<Project, PortfolioContext>, IProjectDal
    {
        public List<ProjectWithTechnologyDto> GetMoreProjectDto()
        {
            using (var context = new PortfolioContext())
            {
                var result = from project in context.Projects
                             join image in context.Images 
                             on project.Id equals image.ProjectId into projectImages
                             from pi in projectImages.DefaultIfEmpty()
                             where pi == null
                             select new ProjectWithTechnologyDto
                             {
                                 demoLink = project.demoLink,
                                 ProjectId = project.Id,
                                 Description = project.Description,
                                 ghLink = project.ghLink,
                                 Title = project.Title,
                                 Technologies= (from projects in context.Projects
                                                join projectTech in context.ProjectTechnologies
                                                on projects.Id equals projectTech.ProjectId
                                                join technology in context.Technologies
                                                on projectTech.TechnologyId equals technology.Id
                                                where projectTech.ProjectId == project.Id
                                                select technology).ToList()
                             };
                return result.ToList();
            }
        }

        public List<ProjectWithImageAndTechnologyDto> GetProjectsWithImageAndTechnology()
        {
            using (var context= new PortfolioContext())
            {/*
                var result = from project in context.Projects
                             select new ProjectWithImageAndTechnologyDto()
                             {
                                 ProjectId = project.Id,
                                 Description = project.Description,
                                 demoLink = project.demoLink,
                                 ghLink = project.ghLink,
                                 Title = project.Title,
                                 Images = (from image in context.Images
                                           join projects in context.Projects
                                           on image.ProjectId equals projects.Id
                                           where project.Id == image.ProjectId && 
                                           select image).ToList(),
                                 Technologies = (from projects in context.Projects
                                                 join projectTech in context.ProjectTechnologies
                                                 on projects.Id equals projectTech.ProjectId
                                                 join technology in context.Technologies
                                                 on projectTech.TechnologyId equals technology.Id
                                                 where projectTech.ProjectId == project.Id
                                                 select technology).ToList()
                             };
                return result.ToList();*/
                var result = from project in context.Projects
                             join image in context.Images
                             on project.Id equals image.ProjectId into images
                             where images.Count() > 0
                             select new ProjectWithImageAndTechnologyDto
                             {
                                 ProjectId = project.Id,
                                 Title = project.Title,
                                 Description = project.Description,
                                 demoLink = project.demoLink,
                                 ghLink = project.ghLink,
                                 Images = images.ToList(),
                                 Technologies = (from projects in context.Projects
                                                 join projectTech in context.ProjectTechnologies
                                                 on projects.Id equals projectTech.ProjectId
                                                 join technology in context.Technologies
                                                 on projectTech.TechnologyId equals technology.Id
                                                 where projectTech.ProjectId == project.Id
                                                 select technology).ToList()
                             };
                return result.ToList();
            }
        }
    }
}
