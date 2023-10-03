using System;

// Abstract Product
public abstract class Vehicle
{
    public abstract void Drive();
}

// Concrete Products
public class Car : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Driving a car.");
    }
}

public class Motorcycle : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Riding a motorcycle.");
    }
}

// Abstract Factory
public abstract class VehicleFactory
{
    public abstract Vehicle CreateVehicle();
}

// Concrete Factories
public class CarFactory : VehicleFactory
{
    public override Vehicle CreateVehicle()
    {
        return new Car();
    }
}

public class MotorcycleFactory : VehicleFactory
{
    public override Vehicle CreateVehicle()
    {
        return new Motorcycle();
    }
}

