using System;
namespace DesignPatterns.Patterns.MVC
{
    public class UserModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class UserView
    {
        public void DisplayUser(UserModel user)
        {
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
        }
    }

    public class UserController
    {
        private UserModel model;
        private UserView view;

        public UserController(UserModel model, UserView view)
        {
            this.model = model;
            this.view = view;
        }

        public void UpdateUserData(string name, int age)
        {
            model.Name = name;
            model.Age = age;
        }

        public void DisplayUserData()
        {
            view.DisplayUser(model);
        }
    }

}

