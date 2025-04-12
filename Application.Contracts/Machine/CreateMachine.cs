using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Machine
{
    public class CreateMachine
    {
        public string Name { get; set; }
        public long HallID { set; get; }
    }
}
