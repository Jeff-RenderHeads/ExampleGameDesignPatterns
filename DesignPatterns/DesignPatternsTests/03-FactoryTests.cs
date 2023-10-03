using DesignPatterns;

namespace DesignPatternsTests;

public class FactoryTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CarFactory_CreateVehicle_ReturnsCar()
    {
        // Arrange
        VehicleFactory factory = new CarFactory();

        // Act
        Vehicle vehicle = factory.CreateVehicle();

        // Assert
        Assert.IsInstanceOf<Car>(vehicle);
    }

    [Test]
    public void MotorcycleFactory_CreateVehicle_ReturnsMotorcycle()
    {
        // Arrange
        VehicleFactory factory = new MotorcycleFactory();

        // Act
        Vehicle vehicle = factory.CreateVehicle();

        // Assert
        Assert.IsInstanceOf<Motorcycle>(vehicle);
    }

    [Test]
    public void Car_Drive_PrintsDrivingACar()
    {
        // Arrange
        Vehicle car = new Car();
        var consoleOut = new StringWriter();
        Console.SetOut(consoleOut);

        // Act
        car.Drive();
        string output = consoleOut.ToString().Trim();

        // Assert
        Assert.AreEqual("Driving a car.", output);
    }

    [Test]
    public void Motorcycle_Drive_PrintsRidingAMotorcycle()
    {
        // Arrange
        Vehicle motorcycle = new Motorcycle();
        var consoleOut = new StringWriter();
        Console.SetOut(consoleOut);

        // Act
        motorcycle.Drive();
        string output = consoleOut.ToString().Trim();

        // Assert
        Assert.AreEqual("Riding a motorcycle.", output);
    }
}
