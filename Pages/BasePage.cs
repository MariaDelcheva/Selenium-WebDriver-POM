using OpenQA.Selenium;


namespace StudentsRegistryPOM.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        // Create virtual property PageURL, which will be different for each page.
        public virtual string PageUrl { get;}

        // Create Constructor: BasePage(IWebDriver driver)

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;   
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
        }

        // Locate all UI elements and mapped to C# properties.

        public IWebElement HomeLink => driver.FindElement(By.XPath("//a[text()='Home']"));
        public IWebElement ViewStudentsLink => driver.FindElement(By.XPath("//a[text()='View Students']"));
        public IWebElement AddStudentsLink => driver.FindElement(By.XPath("//a[text()='Add Student']"));

        // !!!  PageHeading text is different for each page.
        public IWebElement PageHeading => driver.FindElement(By.CssSelector("body>h1"));


        // Create all methods for this page.
        // 1.  Create OpenPage() method, which is responsible for opening a page on a given page URL.

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl); 
        }

        // 2. Create IsOpenPage() boolean method, which checks whether the current URL of the driver is the same as the page URL of our page

        public bool IsOpanPage()
        {
            return driver.Url == this.PageUrl;
        }

        //3.  Create GetPageTitle() method,which return heading text of the current page

        public string GetPageTitle()
        {
            return driver.Title; 
        }

        // 4. Create GetPageHeadingText() method ,which return the text from the ElementPageHeading property

        public string GetPageHeadingText()
        {
            return PageHeading.Text;    
        }
    }
}
