//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Uniqlo.BL.Services.Abstractions;
//using Uniqlo.BL.Services.Concretes;

//namespace Uniqlo.BL.Utilities
//{
//    public static class FileManagerExtension
//    {
//        private static readonly IWebHostEnvironment _webHostEnvironment;

//        public static bool IsValidFormatAndSize(this IFormFile file, string errorMessage)
//        {
//            if (file == null)
//            {
//                errorMessage = "Image is required.";
//                return false;
//            }
//            if (file.Length > 5 * 1024 * 1024)
//            {
//                errorMessage = "Fayl cox boyukdur.";
//                return false;
//            }
//            string[] allowedFormats = { ".jpg", ".png", ".jpeg", ".svg", ".webp" };
//            string extension = Path.GetExtension(file.FileName).ToLower();
//            if (allowedFormats.Contains(extension))
//            {
//                errorMessage = "Icaze yoxdur";
//                return false;
//            }
//            return true;
//        }
//        public static string CreateFileName(IFormFile file)
//        {
//            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "testFoldre");
//            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
//            string extension = Path.GetExtension(file.FileName);
//            if (Path.Exists(Path.Combine(uploadPath, fileName + extension)))
//            {
//                fileName = fileName + Guid.NewGuid().ToString();
//            }

//            return fileName + extension;
//        }

//        public static void CheckDirectory(string uploadPath)
//        {
//            if (!Directory.Exists(uploadPath))
//            {
//                Directory.CreateDirectory(uploadPath);
//            }
//        }


//    }
//}
