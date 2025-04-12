using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Contract.Acconut
{
    public class ChangePassword
    {
        public long ID { set; get; }
        public string Password { set; get; }
        public string RePassword { set; get; }

    }
}
