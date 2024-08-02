using OpenQA.Selenium;
using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
    // TestHomePage inherit the BaseTest class to access the driver
    public class TestHomePage : TestsBase
    {
        [Test]
        public void Test_HomePage_Content()
        {
          // Instantiate the Home page with driver and open the page
            HomePage homePage = new HomePage(driver);
            homePage.OpenPage();

            //	Assert the page title is correct (window title) and page heading is correct (the top heading at the start of the page):

            Assert.Multiple(() =>
            {
                Assert.That(homePage.GetPageTitle(), Is.EqualTo("MVC Example")); 
                Assert.That(homePage.GetPageHeadingText, Is.EqualTo("Students Registry")); 
            
            });

            Assert.True (homePage.GetStudentsCount() > 0);  

        }

        [Test]
        public void Test_HomePage_Links()
        {
            // Instantiate the Home page with driver and open the page
            HomePage homePage = new HomePage(driver);
            homePage.OpenPage();

            // Click on the Home page link and assert the Home page is open
            homePage.HomeLink.Click(); 
            Assert .That(homePage.IsOpanPage, Is.True);

            // Do the same steps from the previous bullet to test the AddStudentsPage and the ViewStudentsPage links:
            homePage.OpenPage();
            homePage.AddStudentsLink.Click();
            Assert.That(new AddStudentPage (driver).IsOpanPage, Is.True);


            homePage.OpenPage();
            homePage.ViewStudentsLink.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpanPage, Is.True);

        }
    }
}
