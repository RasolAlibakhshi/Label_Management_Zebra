using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Base
    {
        public long ID { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime CreaationDateTime { set; get; }
        
    }
}
