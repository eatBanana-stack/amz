using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AmazonTools.Desktop.Common
{
    public class JsonFileExtensions<T> where T : class
    {
        public static T Readr(string path)
        {
            T user;
            try
            {
                StreamReader file = File.OpenText(path);
                var userJson = file.ReadToEnd();

                user = JsonConvert.DeserializeObject<T>(userJson);
                file.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }

        public static void Write(T user, string path)
        {
            try
            {
                string json = File.ReadAllText("UserAccount.json");
                var jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                File.WriteAllText(path, jsonObj);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    public class UserAccount
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Tenant { get; set; }
    }
}
