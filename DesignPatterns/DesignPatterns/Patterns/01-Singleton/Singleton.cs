using System;

namespace DesignPatterns
{
    public class Singleton
    {
        // Private static instance of the class
        private static Singleton? instance = null;

        // Private constructor to prevent instantiation from other classes
        private Singleton()
        {
            Console.WriteLine("Singleton instance created.");
        }

        // Public static method to get the instance of the Singleton
        public static Singleton Instance
        {
            get
            {
                // If the instance doesn't exist, create it
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        // Public method to demonstrate the Singleton functionality
        public void ShowMessage(string message)
        {
            Console.WriteLine($"Singleton says: {message}");
        }
    }
}