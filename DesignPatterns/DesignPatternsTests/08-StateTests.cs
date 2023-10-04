using System;
using DesignPatterns;
using DesignPatterns.Patterns.MVC;
using DesignPatterns.Patterns.Observer;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace DesignPatternsTests
{
    public class StateTests
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
            // Restore the original console output and dispose of StringWriter
            Console.SetOut(originalConsoleOut);
            consoleOutput.Dispose();
        }

        [Test]
        public void Context_TransitionBetweenStates_StateChanges()
        {
            // Arrange
            var context = new Context();

            // Act
            context.Request();
            context.TransitionToState(new StateB());
            context.Request();

            // Assert
            string consoleText = consoleOutput.ToString();
            StringAssert.Contains("Context is in State A", consoleText);
            StringAssert.Contains("Context is in State B", consoleText);
        }
    }
}

