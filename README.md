# Selenium-WebDriver-POM

The project was developed in Visual Studio.

It is structured into two main folders: "Pages" and "Tests".

**Pages Folder:**

A "BasePage" class is created, which contains common methods and functionalities that can be reused across other pages of the application.
Separate files for each page of the application are included, inheriting from the "BasePage" class.

**Tests Folder:**

A "TestsBase" class is created, providing common methods and functionalities that can be reused across various test classes.
Separate test classes are created for each page of the application, inheriting from the "TestsBase" class.

This structure ensures a clear separation of concerns, promoting code reusability and maintainability.

