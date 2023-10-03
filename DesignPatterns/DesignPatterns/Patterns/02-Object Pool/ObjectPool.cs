using System;
using System.Collections.Generic;

// Object to be managed by the pool
public class Connection
{
    public string ConnectionString { get; set; }

    public Connection(string connectionString)
    {
        ConnectionString = connectionString;
        Console.WriteLine($"Created a connection with connection string: {ConnectionString}");
    }

    public void Open()
    {
        Console.WriteLine($"Opened connection to: {ConnectionString}");
    }

    public void Close()
    {
        Console.WriteLine($"Closed connection to: {ConnectionString}");
    }
}

// Object Pool
public class ConnectionPool
{
    private List<Connection> connections = new List<Connection>();
    private string connectionString;

    //Used in testing
    public int ConnectionCount => connections.Count;

    public ConnectionPool(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public Connection AcquireConnection()
    {
        if (connections.Count > 0)
        {
            Connection connection = connections[0];
            connections.RemoveAt(0);
            Console.WriteLine("Reusing an existing connection from the pool.");
            return connection;
        }
        else
        {
            Console.WriteLine("Creating a new connection.");
            return new Connection(connectionString);
        }
    }

    public void ReleaseConnection(Connection connection)
    {
        Console.WriteLine("Returning the connection to the pool.");
        connections.Add(connection);
    }
}
