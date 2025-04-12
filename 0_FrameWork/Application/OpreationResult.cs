using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class OpreationResult
    {
        public string Message { get; set; }
        public bool Succedded { get; set; }

        public OpreationResult()
        {
            Succedded=false;
            Message = "بدون انجام عملیات.";
        }

        public OpreationResult Success(string message="عملیات با موفقیت انجام شد.")
        {
            Succedded=true;
            Message=message;
            return this;
        }
        public OpreationResult Failed(string message)
        {
            Succedded=false;
            Message=message;
            return this;
        }

    }
}
