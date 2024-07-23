using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace TestAutoService.AutoEngine.API.Logic.Generic
{
    // below static class contains all of the helper functions required to API testing layer
    public static class APIHelpers
    {
        // below class contains helpers for reading e.g. reading json file
        public static class Read
        {
            public static IDictionary<string, string> ReadOneToOne_JsonFile_ToDic(string jsonFilePath)
            {
                
                string rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin","");
                string filePath = rootPath + jsonFilePath;

                IDictionary<string, string> dic = new Dictionary<string, string>();

                using (StreamReader r = new StreamReader(filePath))
                {
                    string json = r.ReadToEnd();
                    dic = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
                }

                return dic;
            }
        }


        // below class contains miscellaneous helper functions e.g. adding up two dic<string,string>
        public static class Miscellaneous
        {
            public static IDictionary<string, string> Fn_AddTwoStringDic(IDictionary<string, string> fis, IDictionary<string, string> sec)
            {
                IDictionary<string, string> sum = new Dictionary<string,string>();

                foreach (KeyValuePair<string, string> entry in fis)
                {
                    sum.Add(entry.Key, entry.Value);
                }

                foreach (KeyValuePair<string, string> entry in sec)
                {
                    if (sum.ContainsKey(entry.Key))
                    {
                        sum[entry.Key] = entry.Value;
                    }
                    else
                    {
                        sum.Add(entry.Key, entry.Value);
                    }
                }
                return sum;
            }

            
     
        }

        // below class contains helper function regarding to maintaing and creating logs 
        public static class LogAPI
        {

            private static string Fn_GetDateStamp()
            {
                DateTime dateTime = DateTime.Now;
                string stampDateTime = dateTime.ToString("dddd dd MMMM yyy  HH  mm ss tt");
                return stampDateTime;
            }
            

            public static void Fn_WriteLogsForAPI(string fileName, string data,string path = "\\Outputs\\API\\Logs\\")
            {
                string rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin","");
                
                string fullFilePath = rootPath + path + fileName;

                try
                {

                    string startLog = "============================== Start Log ==============================";
                    string timeStamp = "          Time Stamp: " + Fn_GetDateStamp();
                    string header = "=======================================================================";
                
                    string endLog = "============================== End Log ================================";

                    using (StreamWriter writer = File.AppendText(fullFilePath))
                    {
                        writer.WriteLine("");
                        writer.WriteLine(startLog);
                        writer.WriteLine(timeStamp);
                        writer.WriteLine(header);
                        writer.WriteLine(data);
                        writer.WriteLine(endLog);
                        writer.WriteLine("");
                        writer.Close();
                    }


                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }

            }
        }


    }

}
