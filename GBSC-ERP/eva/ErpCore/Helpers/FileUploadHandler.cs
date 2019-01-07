using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Helpers
{
    public class FileUploadHandler
    {
        public static string GetFilePathForUpload(string documentfolder, string filename)
        {
            string DirPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", documentfolder);

            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }
            string FilePath = Path.Combine(DirPath, filename);

            return FilePath;
        }

        public static string FileReturnPath(string documentfolder, string filename)
        {
            string returnPath = Path.Combine(documentfolder, filename);

            return returnPath;
        }

        public static string GetFileExtension(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return null;
            }
            int index = filename.LastIndexOf('.');
            string ext = filename.Substring(index + 1);
            return ext;
        }

        public static string GetRootPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
