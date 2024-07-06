using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Job:IEntity
    {
        public int Id { get; set; }
        public string Tab { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? EndedDate { get; set; }
        public string Title { get; set; }
    }
}
