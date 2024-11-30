namespace PB303_ADONet.Exceptions;

public class NotFoundException:Exception
{
    public NotFoundException(string message="Not found"):base(message)
    {
        
    }
}
