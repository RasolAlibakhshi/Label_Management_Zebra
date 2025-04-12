using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Machine:Base
    {
       
        public string Name { get; set; }

        public Machine()
        {
            
        }

        public Machine(long hallID,string name)
        {
            Name = name;
            CreaationDateTime= DateTime.Now;
            IsDeleted=false;
            HallID=hallID;
        
        }

        public void Edit(long hallID, string name)
        {
            Name = name;
            HallID=hallID;
        }

        public void Remove()
        {
            IsDeleted=true;
        }

        public void Restore()
        {
            IsDeleted=false;
        }
        public long HallID { get; set; }
        
        public  Hall Hall { get; set; }


        public List<label> Labels { get; set; }
    }
}
