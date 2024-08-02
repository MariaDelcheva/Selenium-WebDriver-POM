using OpenQA.Selenium;

namespace StudentsRegistryPOM.Pages
{
    // The HomePage class inherits the BasePage class 
    public class HomePage : BasePage
    {
        // Create Constructor: HomePage(IWebDriver driver) 
        public HomePage(IWebDriver driver) : base (driver)
        { 
        }

        // Override the PageURL property with the URL of the Home page of the app 
        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/";


        // Create the ElementStudentsCount property, which locates the count of registered students on the page
        public IWebElement ElementStudentsCount => driver.FindElement(By.CssSelector("body > p > b"));


        // Create GetStudentsCount() method
        public int  GetStudentsCount()
        {
           string studentsCountString = this.ElementStudentsCount.Text;
           return int.Parse(studentsCountString);

        }
    }
}
