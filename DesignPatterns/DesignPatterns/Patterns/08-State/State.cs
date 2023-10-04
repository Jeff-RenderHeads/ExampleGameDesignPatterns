using System;
namespace DesignPatterns
{
    public class Context
    {
        private IState currentState;

        public Context()
        {
            // Initialize with an initial state
            currentState = new StateA();
        }

        public void TransitionToState(IState newState)
        {
            currentState = newState;
        }

        public void Request()
        {
            currentState.HandleState(this);
        }
    }

    public interface IState
    {
        void HandleState(Context context);
    }

    public class StateA : IState
    {
        public void HandleState(Context context)
        {
            Console.WriteLine("Context is in State A");
            // Perform actions specific to State A
        }
    }

    public class StateB : IState
    {
        public void HandleState(Context context)
        {
            Console.WriteLine("Context is in State B");
            // Perform actions specific to State B
        }
    }

}

