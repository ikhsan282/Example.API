using MyPhotos.API.Utilities;
using System.Security.Cryptography;
using System.Text;

namespace Example.API.Utility
{
    public class Public
    {
        public static string PATH_IMAGE = Path.GetFullPath(Environment.CurrentDirectory + @"\wwwroot\Images");

        public static string encryptPassword(string password)
        {
            MD5 mD5 = MD5.Create();
            return string.Concat(mD5.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(a => a.ToString("x2")));
        }
    }
}