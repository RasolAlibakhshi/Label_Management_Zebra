using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class LabelType:Base
    {
        public LabelType()
        {
            
        }

        public LabelType(long hallId, string name, string description, string labelUrl)
        {
            HallID = hallId;
            Name = name;
            Description = description;
            LabelURL = labelUrl;
            CreaationDateTime= DateTime.Now;
            IsDeleted=false;
        }

        public void Edit(long hallId, string name, string description, string labelUrl)
        {
            HallID = hallId;
            Name = name;
            Description = description;
            if (!string.IsNullOrWhiteSpace(labelUrl))
            {
                LabelURL = labelUrl;
            }
            
        }


        public void Remove()
        {
            IsDeleted=true;
        }

        public void Restore()
        {
            IsDeleted=false;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string LabelURL { get; set; }
        public long HallID { get; set; }
        public Hall Hall { get; set; }
    }
}
