using System;
namespace DesignPatterns.Patterns.Observer
{
    public interface IObserver
    {
        void Update(string message);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class ConcreteSubject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string state;

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(state);
            }
        }

        public void SetState(string newState)
        {
            state = newState;
            NotifyObservers();
        }
    }

    public class ConcreteObserver : IObserver
    {
        private string name;

        public ConcreteObserver(string name)
        {
            this.name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{name} received message: {message}");
        }
    }

}

