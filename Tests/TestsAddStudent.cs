using OpenQA.Selenium.DevTools.V125.Network;
using StudentsRegistryPOM.Pages;


namespace StudentsRegistryPOM.Tests
{
    public class TestsAddStudent : TestsBase
    {
        [Test]  
        public void Test_TestAddStudentPage_Content()
        {
            // Instantiate the AddStudentPage class with driver and open AddStudentPage page
                  AddStudentPage addStudentPage = new AddStudentPage(driver);
                  addStudentPage.OpenPage();

            // Assert the page title and heading are correct

            Assert.Multiple(() => 
                {
                    Assert.That(addStudentPage.GetPageTitle(), Is.EqualTo("Add Student")); 
                    Assert.That(addStudentPage.GetPageHeadingText, Is.EqualTo("Register New Student")); 
                });

            // Assert the form fields are empty
            Assert.That(addStudentPage.FieldName.Text, Is.Empty);
            Assert.That(addStudentPage.FieldEmail.Text, Is.Empty);

            // Assert that the form button has a correct text
            Assert.That(addStudentPage.AddButton.Text, Is.EqualTo("Add"));
        }


        [Test]
        public void Test_AddStudentsPage_Links()
        {
            // Instantiate the AddStudentPage class with driver and open Add Student page
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();

            // Click on the AddStudentPage link and assert the AddStudentPage is open
            addStudentPage.AddStudentsLink.Click();
            Assert.That(addStudentPage.IsOpanPage, Is.True);

            // Assert the Home page link opens the page
            addStudentPage.OpenPage();
            addStudentPage.HomeLink.Click();
            Assert.That(new HomePage(driver).IsOpanPage, Is.True);

            // Assert the Add Student page link opens the page
            addStudentPage.OpenPage();
            addStudentPage.AddStudentsLink.Click();
            Assert.That(new AddStudentPage(driver).IsOpanPage, Is.True);

            // Assert the View Students page link opens the page
            addStudentPage.OpenPage();
            addStudentPage.ViewStudentsLink.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpanPage, Is.True);

        }

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent ()
        {
            // Instantiate the AddStudentPage class with driver and open Add Student page
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();

            // Generate a unique student name and email:
            //	string name = "New student" + DateTime.Now.Ticks;
             string name = GenerateRandomName();

            //	string email = "email" + DateTime.Now.Ticks + "@email.com";
            string email = GenerateRandomEmail(name);

            // Invoke the AddStudent(string name, string email) method
            addStudentPage.AddStudent(name, email);

            // Instantiate the ViewStudentsPage class with driver and open View Students page
            ViewStudentsPage viewStudentPage = new ViewStudentsPage(driver);
            Assert.That(viewStudentPage.IsOpanPage, Is.True);   
            
            // studentsPage.GetStudentsList() collection should include the new student
            var students = viewStudentPage.GetStudentsList();   
            string newStudentFullString = name + " (" + email + ")";

            // Assert the page contains the new student
            Assert.True(students.Contains(newStudentFullString)); 
            
        }


        private string GenerateRandomName()
        {
            var random = new Random();
            string[] names = { "Ivan", "Alex", "Mimi" };

            return names[random.Next(names.Length)] + random.Next(999, 9999).ToString();

        }


        private string GenerateRandomEmail(string name)
        {
            var random = new Random();

            return name.ToLower() + random.Next(999, 9999).ToString() + "@gmail.com";

        }


        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            // Instantiate the AddStudentPage class with driver and open Add Student page
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();


            // Invoke the AddStudent(string name, string email) method with invalid data, e.g. an empty name
            addStudentPage.AddStudent("", "mimi@gmai.com");

            // Assert the Add Student page is still open
            Assert.That(addStudentPage.IsOpanPage, Is.True);

            // Assert that the error message contains the Cannot add student text
            Assert.That(addStudentPage.GetErrorMsg(), Is.EqualTo("Cannot add student. Name and email fields are required!"));

        }

    }
    
}
