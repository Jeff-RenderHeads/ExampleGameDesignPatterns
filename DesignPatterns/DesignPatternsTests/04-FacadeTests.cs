using System;
using DesignPatterns;

namespace DesignPatternsTests
{
    public class FacadeTests
    {
        [Test]
        public void WatchMovie_ShouldTurnOnAllComponents()
        {
            // Arrange
            HomeTheaterFacade theater = new HomeTheaterFacade();

            // Act
            theater.WatchMovie("Test Movie");

            // Assert
            Assert.IsTrue(theater.dvdPlayer.IsOn);
            Assert.IsTrue(theater.projector.IsOn);
            Assert.IsTrue(theater.audioSystem.IsOn);
            Assert.That(theater.projector.InputName == "DVD Player");
            Assert.That(theater.audioSystem.Volume == 10);
            Assert.That(theater.dvdPlayer.MovieName == "Test Movie");
        }

        [Test]
        public void EndMovie_ShouldTurnOffAllComponents()
        {
            // Arrange
            HomeTheaterFacade theater = new HomeTheaterFacade();

            // Act
            theater.WatchMovie("Test Movie");
            theater.EndMovie();

            // Assert
            Assert.IsFalse(theater.dvdPlayer.IsOn);
            Assert.IsFalse(theater.projector.IsOn);
            Assert.IsFalse(theater.audioSystem.IsOn);
            Assert.That(theater.projector.InputName == "");
            Assert.That(theater.audioSystem.Volume == 10);
            Assert.That(theater.dvdPlayer.MovieName == "");
        }

        [Test]
        public void WatchMovie_Twice_ShouldNotAffectPreviousState()
        {
            // Arrange
            HomeTheaterFacade theater = new HomeTheaterFacade();

            // Act
            theater.WatchMovie("First Movie");
            theater.WatchMovie("Second Movie");

            // Assert
            Assert.IsTrue(theater.dvdPlayer.IsOn);
            Assert.IsTrue(theater.projector.IsOn);
            Assert.IsTrue(theater.audioSystem.IsOn);
            Assert.That(theater.dvdPlayer.MovieName == "Second Movie");
        }
    }
}

