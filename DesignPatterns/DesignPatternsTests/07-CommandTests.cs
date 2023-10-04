using System;
using DesignPatterns;
using DesignPatterns.Patterns.MVC;
using DesignPatterns.Patterns.Observer;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace DesignPatternsTests
{
    public class CommandTests
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
        public void RemoteControl_TurnOnLight_CommandExecuted()
        {
            // Arrange
            var light = new Light();
            var lightOnCommand = new LightOnCommand(light);
            var remoteControl = new RemoteControl();

            // Act
            remoteControl.SetCommand(lightOnCommand);
            remoteControl.PressButton();

            // Assert
            string consoleText = consoleOutput.ToString();
            StringAssert.Contains("Light is on", consoleText);
        }

        [Test]
        public void RemoteControl_TurnOffLight_CommandExecuted()
        {
            // Arrange
            var light = new Light();
            var lightOffCommand = new LightOffCommand(light);
            var remoteControl = new RemoteControl();

            // Act
            remoteControl.SetCommand(lightOffCommand);
            remoteControl.PressButton();

            // Assert
            string consoleText = consoleOutput.ToString();
            StringAssert.Contains("Light is off", consoleText);
        }
    }
}

