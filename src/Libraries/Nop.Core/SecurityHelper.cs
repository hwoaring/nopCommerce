using System.Security.Cryptography;
using System.Text;

namespace Nop.Core
{
    /// <summary>
    /// 安全类 Helper class
    /// </summary>
    public partial class SecurityHelper
    {
        public static string CreateMD5(string strInput, int length = 32)
        {
            if (string.IsNullOrEmpty(strInput))
                return string.Empty;

            using var md5 = MD5.Create();
            var hashValue = md5.ComputeHash(Encoding.UTF8.GetBytes(strInput));
            var strBuilder = new StringBuilder();
            foreach (var item in hashValue)
                strBuilder.Append(item.ToString("X2"));

            var result = strBuilder.ToString();
            if (length == 16)
                result = result.Substring(8, 16);

            return result;
        }

        public static string CreateFileMD5(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return string.Empty;

            var strBuilder = new StringBuilder();
            using var fileStream = File.OpenRead(filePath);
            using var md5 = MD5.Create();
            var fileValue = md5.ComputeHash(fileStream);
            foreach (var item in fileValue)
                strBuilder.Append(item.ToString("X2"));

            return strBuilder.ToString();
        }


    }
}
