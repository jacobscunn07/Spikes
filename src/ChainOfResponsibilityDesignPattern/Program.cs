
var orca = new OrcaHandler();
var cheetah = new CheetahHandler();
var bison = new BisonHandler();

orca.SetNext(cheetah).SetNext(bison);

Console.WriteLine("Grass");
Console.WriteLine(orca.Handle("Grass"));

Console.WriteLine();

Console.WriteLine("Gazelle");
Console.WriteLine(orca.Handle("Gazelle"));

Console.WriteLine();

Console.WriteLine("Seal");
Console.WriteLine(orca.Handle("Seal"));

public abstract class Handler
{
    private Handler _next;
    
    public Handler SetNext(Handler next)
    {
        _next = next;
        return next;
    }

    public virtual string Handle(string request)
    {
        return _next != null ? _next.Handle(request) : "";
    }
}

public class OrcaHandler : Handler
{
    public override string Handle(string request)
    {
        if (request.ToLower() == "seal")
        {
            return $"Orca: I will eat the {request}";
        }
        else
        {
            return base.Handle(request);
        }
    }
}

public class CheetahHandler : Handler
{
    public override string Handle(string request)
    {
        if (request.ToLower() == "gazelle")
        {
            return $"Cheetah: I will eat the {request}";
        }
        else
        {
            return base.Handle(request);
        }
    }
}

public class BisonHandler : Handler
{
    public override string Handle(string request)
    {
        if (request.ToLower() == "grass")
        {
            return $"Bison: I will eat the {request}";
        }
        else
        {
            return base.Handle(request);
        }
    }
}
