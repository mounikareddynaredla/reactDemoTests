using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;
using ReactSpecFlowTests.ConFigFiles;
using static System.Collections.Specialized.BitVector32;
using ReactSpecFlowTests.Utils;
using OpenQA.Selenium.Support.UI;

namespace ReactSpecFlowTests.PageObjects
{
    public class Login
    {
        IWebDriver driver;
        Login login;
        public Login(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='pagetop']/div[3]/a[1]")]
        public IWebElement SignIn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='LoginForm_login_inputs__18qUB']//input[1]")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='LoginForm_login_inputs__18qUB']//input[2]")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        public IWebElement LogInButton { get; set; }

       
        [FindsBy(How = How.CssSelector, Using = " div[class='LoginForm_error_text__4fzmN']")]
        public IWebElement ErrorMessage { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='tnb-right-section']//a[2]")]
        public IWebElement SignUp { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='SignUpForm_signup_inputs__9QGV9']//input[1]")]
        public IWebElement RegisterEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='SignUpForm_signup_inputs__9QGV9']//input[2]")]
        public IWebElement RegisterPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='SignUpForm_signup_inputs__9QGV9']//input[3]")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='SignUpForm_signup_inputs__9QGV9']//input[4]")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='SignUpForm_signup_buttons__aoBad']//button[1]")]
        public IWebElement SignUpButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='SignUpForm_error_text__vt1BO']")]
        public IWebElement UserAlreadyExistsError { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='SignUpForm_error_text__vt1BO']")]
        public IWebElement FillDetailsError { get; set; }

        [FindsBy(How = How.Id, Using = "logout-link")]
        public IWebElement LogOut { get; set; }

        public void LaunchSite()
        {
            string url = ConfigReader.GetConfigurationFromJson("siteUrl");
            driver.Navigate().GoToUrl(url);
           
        }

        public void EnterLoginDetails()
        {
            string id = ConfigReader.GetConfigurationFromJson("userName");
            string pwd = ConfigReader.GetConfigurationFromJson("password");
            
        }

        public  void ClickOnWebElement(IWebElement Element, long waitTimeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));

            IWebElement ele = wait.Until(ExpectedConditions.ElementToBeClickable(Element));
            ele.Click();
        }

        public  void VisibilityOfWebElement(IWebElement Element, long waitTimeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));

            IWebElement ele = wait.Until(ExpectedConditions.ElementIsVisible((By)Element));
        }

        public  void SensKeysOnWebElement(IWebElement Element, string text)
        {
            Element.SendKeys(text);
        }


    }
}
