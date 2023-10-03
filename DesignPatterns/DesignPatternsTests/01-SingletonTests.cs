using DesignPatterns;

namespace DesignPatternsTests;

public class SingletonTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SingletonTest()
    {
        Singleton singleton1 = Singleton.Instance;
        Singleton singleton2 = Singleton.Instance;

        Assert.That(singleton1 == singleton2, "Singletons do not match");
    }
}
