using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace StudentsRegistryPOM.Pages
{
    // ViewStudentsPage  class also inherits the BasePage class
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base (driver)
        { 
        }

        // Override the PageURL property with the URL of the View Students of the app 

        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/students";


        // Create ListItemsStudents (of type ReadOnlyCollection < IWebElement > , ListItemsStudents take all register students)
        public ReadOnlyCollection<IWebElement> ListItemsStudents => driver.FindElements(By.CssSelector("body > ul > li"));


        // Create GetStudentsList() method , which returns string[]

        public string[] GetStudentsList()
        {
            var elementsStudents = this.ListItemsStudents.Select(student => student.Text).ToArray();
            return elementsStudents;    
        }
    }
}
