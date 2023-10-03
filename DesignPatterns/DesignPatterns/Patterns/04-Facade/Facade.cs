using System;
namespace DesignPatterns
{
    // Subsystem: DVD Player
    public class DVDPlayer
    {
        public bool IsOn = false;
        public string MovieName;

        public void TurnOn()
        {
            Console.WriteLine("DVD Player is ON.");
            IsOn = true;
        }

        public void TurnOff()
        {
            Console.WriteLine("DVD Player is OFF.");
            IsOn = false;
            MovieName = "";
        }

        public void PlayMovie(string movie)
        {
            Console.WriteLine($"Playing the movie: {movie}");
            MovieName = movie;
        }
    }

    // Subsystem: Projector
    public class Projector
    {
        public bool IsOn = false;
        public string InputName;

        public void TurnOn()
        {
            Console.WriteLine("Projector is ON.");
            IsOn = true;
        }

        public void TurnOff()
        {
            Console.WriteLine("Projector is OFF.");
            IsOn = false;
            InputName = "";
        }

        public void SetInput(string input)
        {
            Console.WriteLine($"Setting input to: {input}");
            InputName = input;
        }
    }

    // Subsystem: Audio System
    public class AudioSystem
    {
        public bool IsOn = false;
        public int Volume;

        public void TurnOn()
        {
            Console.WriteLine("Audio System is ON.");
            IsOn = true;
        }

        public void TurnOff()
        {
            Console.WriteLine("Audio System is OFF.");
            IsOn = false;
        }

        public void SetVolume(int volume)
        {
            Console.WriteLine($"Setting volume to {volume}");
            Volume = volume;
        }
    }

    // Facade: Home Theater
    public class HomeTheaterFacade
    {
        public DVDPlayer dvdPlayer;
        public Projector projector;
        public AudioSystem audioSystem;

        public HomeTheaterFacade()
        {
            dvdPlayer = new DVDPlayer();
            projector = new Projector();
            audioSystem = new AudioSystem();
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            dvdPlayer.TurnOn();
            projector.TurnOn();
            projector.SetInput("DVD Player");
            audioSystem.TurnOn();
            audioSystem.SetVolume(10);
            dvdPlayer.PlayMovie(movie);
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting down the home theater...");
            dvdPlayer.TurnOff();
            projector.TurnOff();
            audioSystem.TurnOff();
        }
    }
}

