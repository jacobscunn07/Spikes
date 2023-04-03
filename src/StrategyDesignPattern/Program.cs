var strategies = System
    .Reflection
    .Assembly
    .GetExecutingAssembly()
    .GetTypes()
    .Where(x => x.GetInterfaces().Contains(typeof(IShippingStrategy)))
    .Select(x => (IShippingStrategy)Activator.CreateInstance(x));

Console.Write("Enter shipping code: ");
var code = Console.ReadLine();
var strategy = strategies.SingleOrDefault(x => x.CanShip(code), new UnshippableShippingStrategy());
Console.WriteLine(strategy.Ship());

public interface IShippingStrategy
{
    bool CanShip(string code);
    string Ship();
}

public class FedExShippingStrategy : IShippingStrategy
{
    public bool CanShip(string code)
    {
        return code.ToLower() == "fedex";
    }

    public string Ship()
    {
        return "Shipping with FedEx";
    }
}

public class DHLShippingStrategy : IShippingStrategy
{
    public bool CanShip(string code)
    {
        return code.ToLower() == "dhl";
    }

    public string Ship()
    {
        return "Shipping with DHL";
    }
}

public class UPSShippingStrategy : IShippingStrategy
{
    public bool CanShip(string code)
    {
        return code.ToLower() == "ups";
    }

    public string Ship()
    {
        return "Shipping with UPS";
    }
}

public class UnshippableShippingStrategy : IShippingStrategy
{
    public bool CanShip(string code)
    {
        return false;
    }

    public string Ship()
    {
        return "Unable to ship";
    }
}
