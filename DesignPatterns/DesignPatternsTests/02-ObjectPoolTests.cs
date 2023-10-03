using DesignPatterns;

namespace DesignPatternsTests;

public class ObjectPoolTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestReusingObjects()
    {
        // Create a connection pool
        ConnectionPool pool = new ConnectionPool("DatabaseConnectionString");

        // Acquire and use connections
        Connection connection1 = pool.AcquireConnection();
        connection1.Open();
        connection1.Close();
        pool.ReleaseConnection(connection1);

        Connection connection2 = pool.AcquireConnection();
        connection2.Open();
        connection2.Close();
        pool.ReleaseConnection(connection2);

        // Acquire another connection (should reuse the existing one)
        Connection connection3 = pool.AcquireConnection();
        connection3.Open();
        connection3.Close();
        pool.ReleaseConnection(connection3);

        Assert.That(pool.ConnectionCount == 1, $"Pool count does not match. ({pool.ConnectionCount})");
    }

    [Test]
    public void TestCreatingObjects()
    {
        // Create a connection pool
        ConnectionPool pool = new ConnectionPool("DatabaseConnectionString");

        Connection connection1 = pool.AcquireConnection();
        connection1.Open();

        Connection connection2 = pool.AcquireConnection();
        connection2.Open();

        Connection connection3 = pool.AcquireConnection();
        connection3.Open();

        connection1.Close();
        pool.ReleaseConnection(connection1);

        connection2.Close();
        pool.ReleaseConnection(connection2);

        connection3.Close();
        pool.ReleaseConnection(connection3);

        Assert.That(pool.ConnectionCount == 3, $"Pool count does not match. ({pool.ConnectionCount})");
    }
}
