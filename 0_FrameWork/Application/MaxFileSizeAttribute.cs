using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _0_Framework.Application
{
    public class MaxFileSizeAttribute:ValidationAttribute,IClientModelValidator
    {
        private readonly int _maxfilesize;

        public MaxFileSizeAttribute(int maxfilesize)
        {
            _maxfilesize = maxfilesize;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-maxFileSize", ErrorMessage);
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) return true;
            if (file.Length>_maxfilesize)
            {
                return false;
            }
            return true;
        }
    }
}
