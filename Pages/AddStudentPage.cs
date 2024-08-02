using OpenQA.Selenium;

namespace StudentsRegistryPOM.Pages
{
    public class AddStudentPage : BasePage 

    {
        public AddStudentPage(IWebDriver driver) : base (driver )
        {
        }

      // Override the PageURL property with the URL of the Add Students of the app 
       public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/add-student";

     // Locate all UI elements and mapped to C# properties.

        public IWebElement FieldName => driver.FindElement(By.XPath("//input[@name='name']"));
        public IWebElement FieldEmail => driver.FindElement(By.XPath("//input[@name='email']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//form//button[@type='submit']"));

        public IWebElement ElementErrorMsg => driver.FindElement(By.XPath("//div[text() ='Cannot add student. Name and email fields are required!']"));

        // Create methods 
        // 1.Create AddStudent method (string name, string email)

        public void AddStudent (string name, string email)
        {
            this.FieldName.SendKeys (name);
            this.FieldEmail.SendKeys (email);
            this.AddButton.Click(); 
        }

        // 2.Create GetErrorMsg()
        public string GetErrorMsg()
        {
            return ElementErrorMsg.Text;    
        }

    }
}
