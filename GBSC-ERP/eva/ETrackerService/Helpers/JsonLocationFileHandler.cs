using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Helpers
{
    public static class JsonLocationFileHandler
    {
        public static string GetJsonFilePath(string documentfolder, string filename)
        {
            string DirPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", documentfolder);

            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            string FilePath = Path.Combine(DirPath, filename);

            if (!System.IO.File.Exists(FilePath))
            {
                CreateFile(FilePath);
            }

            return FilePath;
        }

        public static void WriteToLocationHistory(string path, string data)
        {
            InternalWriteAllText(path, data, Encoding.UTF8);
        }

        private static void InternalWriteAllText(string path, string contents, Encoding encoding)
        {
            Contract.Requires(path != null);
            Contract.Requires(encoding != null);
            Contract.Requires(path.Length > 0);
            using (StreamWriter sw = new StreamWriter(path, false, encoding))
                sw.Write(contents);
        }

        internal static void CreateFile(string filePath)
        {
            var myFile = File.Create(filePath); //create file
                                                //some other operations here like writing into the text file
            myFile.Close(); //close text file
        }

        public static string ReadFile(string filename)
        {
            string text;
            var fileStream = new FileStream(filename, FileMode.Open,
            FileAccess.Read); //open text file
                              //vvv read text file (or however you implement it like here vvv
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }
            //finally, close text file
            fileStream.Close();

            return text;
        }
    }
}
