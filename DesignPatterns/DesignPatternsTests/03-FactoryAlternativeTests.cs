using DesignPatterns;

namespace DesignPatternsTests
{
    public class FactoryAlternativeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateCar()
        {
            Factory carFactory = new Factory("CarFactory");
            carFactory.AddBehaviour(new CarBehaviour());

            carFactory.Produce();

            Assert.That(carFactory.OutPile.Count == 1, "Did not create an output");
            Assert.That(carFactory.OutPile.Contains(Resource.Car), "Does not have a type of 'Car'");
        }

        [Test]
        public void CreateMotorcycle()
        {
            Factory carFactory = new Factory("MotorcycleFactory");
            carFactory.AddBehaviour(new MotorcycleBehaviour());

            carFactory.Produce();

            Assert.That(carFactory.OutPile.Count == 1, "Did not create an output");
            Assert.That(carFactory.OutPile.Contains(Resource.Motorcycle), "Does not have a type of 'Motorcycle'");
        }

        [Test]
        public void CreateVehicles()
        {
            Factory vehicleFactory = new Factory("VehiclesFactory");
            vehicleFactory.AddBehaviour(new CarBehaviour());
            vehicleFactory.AddBehaviour(new MotorcycleBehaviour());

            vehicleFactory.Produce();

            Assert.That(vehicleFactory.OutPile.Count == 2, "Did not create outputs");
            Assert.That(vehicleFactory.OutPile.Contains(Resource.Car), "Does not have a type of 'Car'");
            Assert.That(vehicleFactory.OutPile.Contains(Resource.Motorcycle), "Does not have type of 'Motorcycle'");
        }
    }
}

