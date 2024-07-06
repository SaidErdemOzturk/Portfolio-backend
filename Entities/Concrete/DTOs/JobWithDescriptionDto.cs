using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class JobWithDescriptionDto:IDto
    {
        public int JobId { get; set; }
        public string Tab { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? EndedDate { get; set; }
        public string Title { get; set; }
        public List<JobDescription> Descriptions { get; set; }
    }
}
