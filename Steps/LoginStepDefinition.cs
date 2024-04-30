using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V122.Network;
using ReactSpecFlowTests.ConFigFiles;
using ReactSpecFlowTests.Drivers;
using ReactSpecFlowTests.PageObjects;
using ReactSpecFlowTests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ReactSpecFlowTests.Steps
{
    [Binding]
    public class LoginStepDefinition
    {
        IWebDriver driver;
        Login login;
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinition(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<DriverScript>("driverscript").SetUp();
        }

        [Given(@"a user is on the registration page")]
        public void GivenAUserIsOnTheRegistrationPage()
        {
            login = new Login(driver);
            login.LaunchSite();
            login.ClickOnWebElement(login.SignUp, 10);
        }

        [When(@"the user enters valid registration details")]
        public void WhenTheUserEntersValidRegistrationDetails()
        {
            
            string key = ConfigReader.GetConfigurationFromJson("password");
            string firstname = ConfigReader.GetConfigurationFromJson("firstName");
            string lastname = ConfigReader.GetConfigurationFromJson("lastName");

            // genearting unique user email id evertime from GenerateUniqueId method in Utilities
            login.SensKeysOnWebElement(login.RegisterEmail, Utilities.GenerateUniqueId());
            login.SensKeysOnWebElement(login.RegisterPassword, key);
            login.SensKeysOnWebElement(login.FirstName, firstname);
            login.SensKeysOnWebElement(login.LastName, lastname);
            login.ClickOnWebElement(login.SignUpButton, 10);
            Thread.Sleep(2000);
        }

        [Then(@"a new user account should be created successfully")]
        public void ThenANewUserAccountShouldBeCreatedSuccessfully()
        {
            
            Console.WriteLine("user created successfully");
            driver.Quit();
        }

        [Given(@"a user with the same user already exists")]
        public void GivenAUserWithTheSameUserAlreadyExists()
        {
            Console.WriteLine("user is on Registration page");
        }

        [When(@"the user tries to register with the existing userid")]
        public void WhenTheUserTriesToRegisterWithTheExistingUserid()
        {
            string id = ConfigReader.GetConfigurationFromJson("userName");
            string key = ConfigReader.GetConfigurationFromJson("password");
            string firstname = ConfigReader.GetConfigurationFromJson("firstName");
            string lastname = ConfigReader.GetConfigurationFromJson("lastName");
            login.SensKeysOnWebElement(login.RegisterEmail, id);
            login.SensKeysOnWebElement(login.RegisterPassword, key);
            login.SensKeysOnWebElement(login.FirstName, firstname);
            login.SensKeysOnWebElement(login.LastName, lastname);
            login.ClickOnWebElement(login.SignUpButton, 10);
        }

        [Then(@"an error message should be displayed, and the registration should not proceed")]
        public void ThenAnErrorMessageShouldBeDisplayedAndTheRegistrationShouldNotProceed()
        {
            string message = login.UserAlreadyExistsError.Text;
            Console.WriteLine("****************User Already Exists****************" + message);
            driver.Quit();
        }

        [When(@"the user submits the registration form with missing required fields")]
        public void WhenTheUserSubmitsTheRegistrationFormWithMissingRequiredFields()
        {
            login.ClickOnWebElement(login.SignUpButton, 10);
            
        }

        [Then(@"appropriate error messages should be displayed, and the registration should not proceed")]
        public void ThenAppropriateErrorMessagesShouldBeDisplayedAndTheRegistrationShouldNotProceed()
        {
            string message = login.FillDetailsError.Text;
            Console.WriteLine("*****************" +message+ "*****************");
            driver.Quit();
        }

        [Given(@"a user navigates to the login page")]
        public void GivenAUserNavigatesToTheLoginPage()
        {
            login = new Login(driver);
            login.LaunchSite();
        }

        [When(@"the user enters valid credentials")]
        public void WhenTheUserEntersValidCredentials()
        {
            login = new Login(driver);
            login.ClickOnWebElement(login.SignIn, 10);
            string id = ConfigReader.GetConfigurationFromJson("userName");
            string key = ConfigReader.GetConfigurationFromJson("password");
            login.SensKeysOnWebElement(login.Email, id);
            login.SensKeysOnWebElement(login.Password, key);
            login.ClickOnWebElement(login.LogInButton, 10);
            
        }

        [Then(@"the user should be successfully logged in")]
        public void ThenTheUserShouldBeSuccessfullyLoggedIn()
        {
            
            string actual = ConfigReader.GetConfigurationFromJson("actualHomePageUrl");
            string expected = driver.Url;
            if(expected.Contains(actual))
            {
                Console.WriteLine("*********** Successfully logged in ***********");
            }
            
            driver.Quit();
        }

        [When(@"the user enters invalid credentials")]
        public void WhenTheUserEntersInvalidCredentials()
        {
            login = new Login(driver);
            login.ClickOnWebElement(login.SignIn, 10);
            string id = ConfigReader.GetConfigurationFromJson("userName");
            string key = ConfigReader.GetConfigurationFromJson("incorrectPassword");
            login.SensKeysOnWebElement(login.Email, id);
            login.SensKeysOnWebElement(login.Password, key);
            login.ClickOnWebElement(login.LogInButton, 10);
            Thread.Sleep(2000);
        }


        [Then(@"an error message should be displayed, and the user should not be logged in")]
        public void ThenAnErrorMessageShouldBeDisplayedAndTheUserShouldNotBeLoggedIn()
        {
            string message = login.ErrorMessage.Text;
            Console.WriteLine("**************Please enter valid deatils*******************" + message);
            driver.Quit();
        }

    }
}
