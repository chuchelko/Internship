namespace Problem6;

internal class ConnectionFailedException : Exception
{
    public ConnectionFailedException(string message) : base(message)
    {

    }
    public ConnectionFailedException() : base()
    {

    }
}
