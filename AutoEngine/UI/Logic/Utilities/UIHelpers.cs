using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;


using System.Collections.Generic;

using System.Threading;
using System.Xml;
using System.IO;

namespace TestAutoService.AutoEngine.UI.Logic.Utilities
{
    // purpose of this class to collect all of the web heplers methods to a centeralized place
    // it contains 3 nested static class at the moment namley [Wait, Config, LogUI]
    public static class UIHelpers
    {
    
        public static class Wait // this class contains web driver wait helper methods
        {
            public static void Fn_ExpWaitUntilElementIsVisible(IWebDriver WebDriver, string xpathStr, int sec)
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(sec));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpathStr)));
            }

            public static void Fn_Fixed_wait(int sec)
            {
                var time = sec * 1000;
                Thread.Sleep(time);
            }
        }

        
        public static class Config // this class provides cml configurayion data from [\Inputs\\UI\\Configuration\\TestConfigurations.xml"]
        {
            // below function parse the TestConfigurations.xml file into to dic<key,value>
            public static IDictionary<string,string> Fn_getUIConfigurations()
            {
                IDictionary<string, string> configDic = new Dictionary<string, string>();
                XmlDocument doc = new XmlDocument();

                string rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "");
                string fileFullPath = rootPath + "\\Inputs\\UI\\Configuration\\TestConfigurations.xml";

                doc.Load(fileFullPath);

                configDic.Add("browser", doc.SelectSingleNode("/configuration/browser").InnerText);
                configDic.Add("enviroment", doc.SelectSingleNode("/configuration/enviroment").InnerText);
                configDic.Add("userName", doc.SelectSingleNode("/configuration/userName").InnerText);
                configDic.Add("userPassword", doc.SelectSingleNode("/configuration/userPassword").InnerText);
                return configDic;
            }

            // below function provides the xml configuration values by using the key
            public static string Fn_getUIconfigValueOnKey(string key)
            {
                IDictionary<string, string> dic = UIHelpers.Config.Fn_getUIConfigurations();
                string value;
                dic.TryGetValue(key, out value);
                return value;
            }
        }


        public static class LogUI // this class is reposible for creating all types(exception/health) of log files for Ui 
        {

            private static string Fn_GetDateStamp()
            {
                DateTime dateTime = DateTime.Now;
                string stampDateTime = dateTime.ToString("dddd dd MMMM yyy  HH  mm ss tt");
                return stampDateTime;
            }


            public static void Fn_WriteLogsForUI(string fileName, string data, string path = "\\Outputs\\UI\\Logs\\")
            {
                string rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "");

                string fullFilePath = rootPath + path + fileName;

                try
                {

                    string startLog = "============================== Start Log ==============================";
                    string timeStamp = "          Time Stamp: " + Fn_GetDateStamp();
                    string header = "=======================================================================";

                    string endLog = "============================== End Log ================================";


                    //using (StreamWriter writer = new StreamWriter(fullFilePath))
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



    } // UIHelpers class ends

}// namespace ends
    

