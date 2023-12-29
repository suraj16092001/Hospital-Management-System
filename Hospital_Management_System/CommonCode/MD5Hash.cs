using Microsoft.AspNetCore.Components.Forms;
using System.Security.Cryptography;
using System.Text;

namespace Hospital_Management_System.CommonCode
{
    public class MD5Hash
    {
        public static string GetMd5Hash(string password) 
        {
            MD5 md5Hash =MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sb = new StringBuilder();
            for (int i= 0;i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }
        
        public static bool verifyPassword(string hashedPassword ,string password )
        {
            string existingPassword = GetMd5Hash(password);
            return existingPassword == hashedPassword;
        }
    }
}
