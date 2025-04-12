using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork
{
    public class StringToFormFile
    {
        public static IFormFile ConvertStringToIFormFile(string content, string fileName = "file.txt")
        {
            // تبدیل رشته به آرایه بایت
            var bytes = Encoding.UTF8.GetBytes(content);

            // ساخت استریم از بایت‌ها
            var stream = new MemoryStream(bytes);

            // ساخت FormFile
            IFormFile file = new FormFile(stream, 0, bytes.Length, "formFile", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            return file;
        }
    }
}
