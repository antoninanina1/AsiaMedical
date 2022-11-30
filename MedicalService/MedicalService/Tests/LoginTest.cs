using MedicalService.Driver;
using MedicalService.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalService.Tests
{
    public class LoginTest
    {
        LoginPage loginPage;
        string Massage = "Login failed! Please ensure the username and password are valid.";
       

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            
        }

        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_EnterInvalidUserName_ShouldNotBeLoginOnPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("Antonina", "ThisIsNotAPassword");

            Assert.That(Massage, Is.EqualTo(loginPage.UserNotLogin.Text));
        }

        [Test]
        public void TC02_EnterInvalidPassword_ShouldNotBeLoginOnPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("John Doe", "TestTestTest");

            Assert.That(Massage, Is.EqualTo(loginPage.UserNotLogin.Text));
        }

        [Test]
        public void TC03_EnterInvalidUserNameAndPassword_ShouldNotBeLoginOnPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("Antonina", "Tasic");

            Assert.That(Massage, Is.EqualTo(loginPage.UserNotLogin.Text));
        }

        [Test]
        public void TC04_EnterValidUserNameAndPassword_ShouldBeLoginOnPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("John Doe", "ThisIsNotAPassword");
            
        }

        [Test]
        public void TC05_EnterNoData_ShouldNotBeLoginOnPage()
        {
            loginPage.AppMedic.Click();
            loginPage.Login("", "");

            Assert.That(Massage, Is.EqualTo(loginPage.UserNotLogin.Text));
        }


    }
}
