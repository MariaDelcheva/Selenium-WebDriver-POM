using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
    public class TestsViewStudents : TestsBase
    {
        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            // Instantiate the ViewStudentsPage class, open the View Students page 
            ViewStudentsPage viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.OpenPage(); 

            // Check its title and heading
            Assert.Multiple(() =>
            {
                Assert.That(viewStudentsPage.GetPageTitle(), Is.EqualTo("Students"));
                Assert.That(viewStudentsPage.GetPageHeadingText, Is.EqualTo("Registered Students"));
            });

            // Invoke the GetRegisteredStudents() method to get all students on the page:
            var students = viewStudentsPage.GetStudentsList();

            // Assert that each student record contains "(" and finishes with ")"
            foreach (string student in students)
            {
                Assert.That(student.Contains("("), Is.True);
                Assert.That(student.LastIndexOf(")") == student.Length - 1, Is.True);
            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            // Instantiate the View Students page with driver and open the page
            ViewStudentsPage viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.OpenPage();

            // Click on the View Students page link and assert the View Students page is open
            viewStudentsPage.ViewStudentsLink.Click();
            Assert.That(viewStudentsPage.IsOpanPage, Is.True);

            // Do the same steps from the previous bullet to test the AddStudentsPage and the ViewStudentsPage links:
            viewStudentsPage.OpenPage();
            viewStudentsPage.AddStudentsLink.Click();
            Assert.That(new AddStudentPage(driver).IsOpanPage, Is.True);


            viewStudentsPage.OpenPage();
            viewStudentsPage.ViewStudentsLink.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpanPage, Is.True);

        }
    }
}
