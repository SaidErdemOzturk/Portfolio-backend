using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class ProjectWithTechnologyDto:IDto
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ghLink { get; set; }
        public string? demoLink { get; set; }
        public List<Technology> Technologies { get; set; }
    }
}
