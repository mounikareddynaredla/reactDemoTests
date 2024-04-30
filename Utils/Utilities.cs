using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReactSpecFlowTests.ConFigFiles;
using SeleniumExtras.WaitHelpers;


namespace ReactSpecFlowTests.Utils
{
   
    public static class Utilities
    {
        
        public static string CurrentDateTime()
        {
            DateTime currentDateTime = DateTime.Now;
            return currentDateTime.ToString();
        }

        public static string GenerateUniqueId()
        {
            Random rnd = new Random();
            string text = rnd.Next().ToString().Substring(1, 3);
            Console.WriteLine(text);
            string emailId = ConfigReader.GetConfigurationFromJson("id");
            string uniqueId = text + emailId;
            Console.WriteLine(uniqueId);
            return uniqueId;
        }

       
    }
}
