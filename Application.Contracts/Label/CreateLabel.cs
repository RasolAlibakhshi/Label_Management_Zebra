using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Label
{
    public class CreateLabel
    {
        public string Interwoven { set; get; }
        public long MachineID { set; get; }
        public string Filament { set; get; }
        public string Den { set; get; }
        public string Ply { set; get; }
        public string Mingel { set; get; }
        public string ColorCode { set; get; }
        public string direction { set; get; }
        public string Emptyfield1 { set; get; }
        public string Emptyfield2 { set; get; }
        public string Emptyfield3 { set; get; }
        public string Emptyfield4 { set; get; }
        public string Emptyfield5 { set; get; }
        public string YarnType { set; get; }
        public string Description { set; get; }
    }
}
