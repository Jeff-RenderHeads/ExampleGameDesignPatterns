# Game Design Patterns

**What are Design Patterns?**

**But first, what is the goal of software development?**

As engineers, we are trying to solve problems to deliver value to users. These problems come in many different shapes and sizes and change based on the size of your project. Sometimes by trying to solve problems, we create new and different problems for ourselves.

**Back to What are Design Patterns**

Design patterns are basically code recipes to help solve recurring problems in software development. 

The Gang of Four came up with a book called “Design Patterns” which detailed 23 design patterns to help engineers.

These patterns aim to Solve common problems, improve maintainability and scalability and lend themselves to being reusable. 

There are 3 categories for design patterns

- Creational, how objects are created
- Structural, how objects relate to each other
- Behavioural, how objects communicate with one another

There are many different opinions about the pro’s and con’s of these patterns so lets jump in

### Singleton Pattern (Creational)

What problem does this solve?

when coding, we often need to retrieve a class to do something, for example,  sound effects. We typically don't need more than one object to manage the sound effects for us and that's not guaranteed if we have unrelated classes trying to make sound effects. 

**Solution:**

Creating a static class that instantiates itself privately if it doesn't already exist otherwise it serves the instantiated reference. This ensures there can only be one that be accessed publically

**Real-world example:**

There can only be one government at a time and everyone living in that country can refer to it when they need something.

**Pros:**

- Ensures that there is only one instance of a class, which can be useful for managing global resources or game managers.
- Provides a central point of access to the instance, making it easy to control and monitor.

**Cons:**

- Can lead to tight coupling in your code, making it less flexible and harder to test.
- Overusing the singleton pattern can make your codebase harder to maintain and understand.

### Object Pool Pattern (Creational)

**What problem does this solve?**

In software development, there are scenarios where creating and destroying objects frequently can be resource-intensive and impact performance. For example, in a game, you might need to create and destroy bullets, enemies, or other objects dynamically. Creating new objects each time can be costly, especially when there are many instances needed for a short duration.

**Solution:**

The Object Pool Pattern addresses this issue by pre-creating a pool of reusable objects when the application starts. Instead of creating new objects when needed, objects are borrowed from the pool, and when they are no longer needed, they are returned to the pool for reuse. This eliminates the overhead of creating and destroying objects continuously.

**Real-world example:**

Think of a car rental service where they maintain a fleet of cars available for rent. Instead of manufacturing a new car for each customer request, they maintain a pool of cars. Customers can rent available cars from the pool, and when they return them, the cars go back to the pool for the next customer.

**Pros:**

- Reduces the overhead of object creation and destruction, improving performance in scenarios with frequent object usage.
- Promotes resource efficiency by reusing objects, especially in resource-constrained environments.
- Allows better control over the maximum number of objects in use, preventing resource exhaustion.

**Cons:**

- Can be overkill for scenarios where object creation and destruction are infrequent or where objects are very lightweight.
- Requires careful management of object state to ensure they are in a consistent state when borrowed from the pool.

### Factory Pattern (Creational)

**What problem does this solve?**

In software development, creating objects directly using constructors can lead to issues when you need flexibility in object creation, such as choosing between different subclasses of objects or customizing object creation based on certain conditions. Additionally, directly creating objects can tightly couple your code to specific classes.

**Solution:**

The Factory Pattern provides a way to create objects without specifying the exact class of object that will be created. Instead of using constructors directly, you delegate the responsibility of object creation to a factory class or method. This allows for centralized and flexible object creation, promoting loose coupling and enhancing code maintainability.

**Real-world example:**

Consider a toy factory that produces different types of toys (e.g., cars, dolls, action figures). Instead of buying a specific toy directly from a store, customers order from the factory. The factory knows how to create various types of toys based on customer requests.

**Pros:**

- Encapsulates object creation, making it easy to change the types of objects created without modifying existing code.
- Promotes loose coupling by creating objects through interfaces or base classes, allowing for easy substitution of objects.
- Provides a centralized point for customization and configuration of objects during creation.

**Cons:**

- Introduces an additional layer of abstraction, which may be unnecessary for simple object creation scenarios.
- Requires the creation of factory classes or methods, which can add complexity to the codebase.

### Facade Pattern (Structural)

**What problem does this solve?**

In software development, complex systems or libraries often have many intricate components and interactions. Accessing and using these components directly can be cumbersome, error-prone, and may require deep knowledge of the system's internals. Users of the system need a simplified and unified interface to interact with it.

**Solution:**

The Facade Pattern provides a simplified and unified interface to a complex subsystem or set of related interfaces. It acts as a "facade" or entry point to the system, shielding clients from the complexity and intricacies of the subsystem's components. This promotes ease of use, reduces dependencies, and encapsulates the system's internals.

**Real-world example:**

Think of a smartphone. Instead of dealing with individual hardware components like the CPU, memory, display, and sensors, you interact with a user-friendly interface (the touchscreen) that abstracts and simplifies access to these complex subsystems.

**Pros:**

- Simplifies the use of complex systems or libraries by providing a high-level, user-friendly interface.
- Reduces dependencies between clients and the subsystem, making it easier to change or replace subsystem components without affecting clients.
- Encapsulates and hides the complexity of the subsystem, enhancing code readability and maintainability.

**Cons:**

- May not be necessary for simple systems or when you don't anticipate changes to the subsystem's components.
- Introducing a facade layer can add an additional abstraction, which might be seen as unnecessary in some cases.

### Model-View-Controller (MVC) Pattern (Structural)

**What problem does this solve?**

In software development, especially in applications with graphical user interfaces, managing the organization, interactions, and updates between the user interface, data, and application logic can become complex. Without a clear separation of concerns, code can become tangled and challenging to maintain.

**Solution:**

The Model-View-Controller (MVC) Pattern provides a structural organization for applications to separate their components into three main parts:

1. **Model**: This represents the application's data and core business logic. It encapsulates data handling and state management, ensuring that data remains consistent and up-to-date.
2. **View**: The View is responsible for presenting the data to the user in a user-friendly format. It handles the graphical user interface (GUI) and how information is displayed to the user.
3. **Controller**: The Controller acts as an intermediary between the Model and View. It processes user input, communicates with the Model to retrieve or update data, and updates the View to reflect changes in the data.

This separation of concerns simplifies application development, improves code organization, and promotes maintainability and scalability.

**Real-world example:**

Consider a web-based email application. The Model represents the user's emails, contacts, and folders, handling data storage and retrieval. The View displays the user interface, including the list of emails and the email content. The Controller manages interactions, such as clicking on an email to view it, and communicates with the Model to fetch and update email data.

**Pros:**

- Promotes a clear separation of concerns, making code easier to understand and maintain.
- Facilitates code reusability since different Views can interact with the same Model.
- Supports parallel development, allowing different teams to work on Models, Views, or Controllers independently.

**Cons:**

- Introduces an additional layer of complexity, which may be unnecessary for simple applications.
- The strict separation can lead to increased communication overhead between the components.

### Observer Pattern (Behavioral)

**What problem does this solve?**

In software development, there are scenarios where objects need to be notified about changes in the state of other objects. For example, in a graphical user interface, multiple elements (like buttons or sliders) need to react when the underlying data changes. A direct approach would involve objects actively checking for changes, which is inefficient and can lead to tight coupling.

**Solution:**

The Observer Pattern provides a behavioural solution to this problem by establishing a one-to-many dependency between objects. In this pattern, one object (the subject) maintains a list of dependent objects (observers) and notifies them of state changes. Observers can then react to changes without being tightly coupled to the subject. This promotes loose coupling and simplifies the management of object interactions.

**Real-world example:**

Consider a stock market monitoring system. Multiple investors want to be notified when the price of a particular stock changes. The stock market serves as the subject, while investors act as observers. When the stock's price changes, all subscribed investors receive notifications and can make investment decisions accordingly.

**Pros:**

- Encourages loose coupling between subjects and observers, making it easier to maintain and extend the system.
- Supports multiple observers for a single subject, allowing for complex relationships between objects.
- Enables dynamic addition and removal of observers without modifying the subject's code.

**Cons:**

- Introduces a potential risk of memory leaks if observers are not properly detached from subjects when they are no longer needed.
- Can lead to increased complexity when many subjects and observers are involved.

### Command Pattern (Behavioral)

**What problem does this solve?**

In software development, it's common to encounter scenarios where you need to encapsulate a request or operation as an object. This allows you to parameterize clients with requests, queue requests, log requests, or even undo/redo operations. The Command Pattern provides a solution to these requirements.

**Solution:**

The Command Pattern is a behavioral design pattern that turns a request or operation into a stand-alone object. This object contains all the information needed to perform the request, including the method to execute it and any necessary parameters. This decouples the sender (client) from the receiver (the object that performs the operation) and allows you to parameterize, queue, and log requests easily.

**Real-world example:**

Imagine a remote control for a television. Each button on the remote represents a command: turning the TV on, changing the channel, adjusting the volume, etc. When you press a button, it sends a command object to the TV, which then executes the corresponding action.

**Pros:**

- Encapsulates requests as objects, allowing for parameterization of clients with requests.
- Enables the creation of complex sequences of commands or macros.
- Supports undo/redo functionality by storing the history of executed commands.
- Allows for queuing and scheduling of commands.

**Cons:**

- May introduce a large number of command classes if the system has many different commands.
- Can increase code complexity, especially when dealing with command hierarchies or complex behaviors.

### State Pattern (Behavioral)

**What problem does this solve?**

In software development, there are situations where an object's behavior changes based on its internal state, and the transitions between states can be complex. Implementing this behavior using conditional statements (e.g., if-else) can lead to code that's hard to maintain and extend. The State Pattern provides a solution for managing state-specific behavior in a cleaner and more organized way.

**Solution:**

The State Pattern is a behavioral design pattern that allows an object to change its behavior when its internal state changes. It achieves this by representing each state as a separate class and allowing the context (the object whose behavior changes) to delegate state-specific behavior to the current state object. As the internal state changes, the context switches to a different state object, effectively changing its behavior.

**Real-world example:**

Consider a vending machine. It can be in different states, such as "Ready," "Dispensing," or "Out of Stock." Depending on its state, the actions (e.g., inserting coins, selecting a product) have different effects. The State Pattern can be used to manage these states and their associated behaviors.

**Pros:**

- Encapsulates state-specific behavior in separate classes, making the code easier to understand and maintain.
- Removes the need for complex conditional statements to manage state transitions.
- Allows for the addition of new states or changes to existing states without affecting the context class.

**Cons:**

- Can lead to a larger number of classes in the codebase, especially in systems with many states.
- May introduce complexity when state transitions have intricate rules or dependencies.
