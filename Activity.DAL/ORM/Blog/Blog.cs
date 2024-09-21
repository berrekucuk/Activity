using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.DAL.ORM
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
