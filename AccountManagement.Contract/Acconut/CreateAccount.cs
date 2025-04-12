using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Contract.Acconut
{
    public class CreateAccount
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long RoleID { get; set; }
        public IFormFile ProfilePhoto { get; set; }
    }
}
