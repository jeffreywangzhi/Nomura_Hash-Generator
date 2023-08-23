using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace fileEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            // get configurations
            // target csv file
            string value1
                = System.Configuration.ConfigurationManager.AppSettings["inputPath"] == null ?
                    null : System.Configuration.ConfigurationManager.AppSettings["inputPath"].ToString();
            // hash mode (0:MD5, 1:SHA-1, 2:SHA256, 3:SHA512)
            string value2
                = System.Configuration.ConfigurationManager.AppSettings["hashMode"] == null ?
                    null : System.Configuration.ConfigurationManager.AppSettings["hashMode"].ToString();
            // case (U:uppercase, L:lowercase)
            string s
                = System.Configuration.ConfigurationManager.AppSettings["case"] == null ?
                    null : System.Configuration.ConfigurationManager.AppSettings["case"].ToString();
            string value3 = "";
            string value4
                = System.Configuration.ConfigurationManager.AppSettings["outputPath"] == null ?
                    null : System.Configuration.ConfigurationManager.AppSettings["outputPath"].ToString();       

            // get csv file
            string[] files = Directory.GetFiles(value1, "file*.csv");
            string value = files[0];
            Console.WriteLine("inputPath: " + value)
            // set case
            if(s == "U")
            // tbc


        }
    }
}