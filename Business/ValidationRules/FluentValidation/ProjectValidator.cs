using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProjectValidator :AbstractValidator<Project>
    {
        public ProjectValidator() 
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}
