using System;
using DesignPatterns;
using DesignPatterns.Patterns.MVC;
using DesignPatterns.Patterns.Observer;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace DesignPatternsTests
{
    public class ObserverTests
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
        public void ConcreteObserver_UpdatesWhenNotified()
        {
            // Arrange
            var concreteSubject = new ConcreteSubject();
            var observerA = new ConcreteObserver("Observer A");
            var observerB = new ConcreteObserver("Observer B");

            // Act
            concreteSubject.RegisterObserver(observerA);
            concreteSubject.RegisterObserver(observerB);
            concreteSubject.SetState("New State");

            // Assert
            string consoleText = consoleOutput.ToString();
            StringAssert.Contains("Observer A received message: New State", consoleText);
            StringAssert.Contains("Observer B received message: New State", consoleText);
        }

        [Test]
        public void ConcreteObserver_DoesNotUpdateAfterRemoval()
        {
            // Arrange
            var concreteSubject = new ConcreteSubject();
            var observerA = new ConcreteObserver("Observer A");
            var observerB = new ConcreteObserver("Observer B");

            // Act
            concreteSubject.RegisterObserver(observerA);
            concreteSubject.RegisterObserver(observerB);
            concreteSubject.RemoveObserver(observerA);
            concreteSubject.SetState("New State");

            // Assert
            string consoleText = consoleOutput.ToString();
            StringAssert.DoesNotContain("Observer A received message:", consoleText);
            StringAssert.Contains("Observer B received message: New State", consoleText);
        }
    }
}

