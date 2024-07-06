using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProjectTechnology:IEntity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TechnologyId { get; set; }
    }
}
