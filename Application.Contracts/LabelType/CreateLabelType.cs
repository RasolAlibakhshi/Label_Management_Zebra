using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.LabelType
{
    public class CreateLabelType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile LabelURL { get; set; }
        public long HallID { get; set; }
    }
}
