using Microsoft.AspNetCore.Http;
using Nibo.Business.Interfaces;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nibo.Business.Services
{
    public class IOService : IIOService
    {

        private string folder = @"F:\Projetos\NiboTest\SRC\Nibo.App\wwwroot\Data\";


        public StringBuilder ReadFile(string fileName)
        {
            if (!FileNameIsValid(fileName)) throw new FileLoadException("Extension is not valid");

            fileName = folder + fileName;

            var builder = new StringBuilder();

            using (FileStream fs = File.OpenRead(fileName))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    builder.Append(temp.GetString(b));
                }
            }

            return builder;
        }

        private bool FileNameIsValid(string name)
           => Regex.IsMatch(name.ToLower(), "^([a-zA-Z0-9-_ ]{2,30})\\.(ofx)+$");
    }
}
