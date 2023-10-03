using System;
using DesignPatterns;
using DesignPatterns.Patterns.MVC;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace DesignPatternsTests
{
    public class MVCTests
    {
        private StringWriter consoleOutput;
        private TextWriter originalConsoleOut;

        [SetUp]
        public void RedirectConsoleOutput()
        {
            // Redirect console output to a StringWriter
            consoleOutput = new StringWriter();
            originalConsoleOut = Console.Out;
            Console.SetOut(consoleOutput);
        }

        [TearDown]
        public void RestoreConsoleOutput()
        {
            // Restore the original console output
            Console.SetOut(originalConsoleOut);
            consoleOutput.Dispose();
        }

        [Test]
        public void UserController_UpdateUserData_ShouldUpdateModel()
        {
            // Arrange
            var userModel = new UserModel();
            var userView = new UserView();
            var userController = new UserController(userModel, userView);

            // Act
            userController.UpdateUserData("John Doe", 30);

            // Assert
            Assert.That(userModel.Name == "John Doe");
            Assert.That(userModel.Age == 30);
        }

        [Test]
        public void UserController_DisplayUserData_ShouldDisplayInView()
        {
            // Arrange
            var userModel = new UserModel { Name = "Alice", Age = 25 };
            var userView = new UserView();
            var userController = new UserController(userModel, userView);

            // Act
            userController.DisplayUserData();

            // Assert
            string consoleText = consoleOutput.ToString();
            StringAssert.Contains("Name: Alice", consoleText);
            StringAssert.Contains("Age: 25", consoleText);
        }
    }
}

