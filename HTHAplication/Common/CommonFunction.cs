using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTHApplication.Common
{
    public class CommonFunction
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string ADMIN_GROUP = "ADMIN";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CurrentCulture { set; get; }
        public static string GeneratedID(string id, long? value = 1)
        {
            string str = id;
            string val = value.ToString();
            int count = 15 - str.Length - val.Length;
            string strTmp = "";
            for (int i = 1; i <= count; i++)
            {
                strTmp += "0";
            }
            return (str + strTmp + val);

        }
        public static string GenerateMaHang(string id, long? value = 1)
        {
            return id + value.ToString();
        }
               
    }
}