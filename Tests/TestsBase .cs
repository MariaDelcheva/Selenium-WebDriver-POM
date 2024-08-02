using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StudentsRegistryPOM.Tests
{
    public class TestsBase
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()  
        {
            driver = new ChromeDriver();    
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();   
        }

    }
}
