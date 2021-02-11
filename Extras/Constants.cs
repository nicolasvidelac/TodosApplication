using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Extras
{
    public static class Constants
    {
        public const string Audiance = "https://localhost:44320/";
        public const string Issuer = Audiance;
        public const string Secret = "not_too_short_secret_otherwise_it_might_error";


        public const string Key = "adjhfiupsdfhgiuaw";

        public static string EncryptPwd(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            password += Key;
            var pwdBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(pwdBytes);
        }

        public static string DecryptPwd(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            var pwdBytes = Convert.FromBase64String(password);
            var result = Encoding.UTF8.GetString(pwdBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }

    }
}
