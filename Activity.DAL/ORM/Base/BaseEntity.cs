using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.DAL.ORM
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTime AddDate { get; set; } 
        public DateTime DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
