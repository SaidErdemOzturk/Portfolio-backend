using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Profile:IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public string MoreDescription { get; set; }
    }
}
