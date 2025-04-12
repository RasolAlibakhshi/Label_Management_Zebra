using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Hall:Base
    {
        public string Name { get; set; }
        public Hall(){}
        public Hall(string name)
        {
            Name = name;
            IsDeleted = false;
            CreaationDateTime= DateTime.Now;
        }

        public void Edit(string name)
        {
            Name = name;
        }

        public void Remove()
        {
            IsDeleted=true;
        }

        public void Restore()
        {
            IsDeleted=false;
        }

        public List<Machine> Machines { get; set; }
        public List<LabelType> LabelTypes { get; set; }


}
}
