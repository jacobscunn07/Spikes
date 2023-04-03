var computer = new Computer(new ComputerStateOn());

Console.WriteLine("Sleep:");
computer.PushSleep();

Console.WriteLine();

Console.WriteLine("On:");
computer.PushOn();

Console.WriteLine();

Console.WriteLine("Off:");
computer.PushOff();

Console.WriteLine();

Console.WriteLine("Sleep:");
computer.PushSleep();

public class Computer
{
    private ComputerState _state;

    public Computer(ComputerState state)
    {
        _state = state;
        _state.SetComputer(this);
    }

    public void TransitionTo(ComputerState state)
    {
        Console.WriteLine($"Computer is transitioning from {_state.GetType().Name} to {state.GetType().Name}");
        _state = state;
        _state.SetComputer(this);
    }

    public void PushOn()
    {
        _state.PushOn();
    }

    public void PushOff()
    {
        _state.PushOff();
    }

    public void PushSleep()
    {
        _state.PushSleep();
    }
}

public abstract class ComputerState
{
    protected Computer _computer;

    public void SetComputer(Computer computer)
    {
        _computer = computer;
    }

    public abstract void PushOn();

    public abstract void PushOff();

    public abstract void PushSleep();
}

public class ComputerStateOn : ComputerState
{
    public override void PushOn()
    {
        Console.WriteLine("Computer is already turned on");
    }

    public override void PushOff()
    {
        _computer.TransitionTo(new ComputerStateOff());
    }

    public override void PushSleep()
    {
        _computer.TransitionTo(new ComputerStateSleep());
    }
}

public class ComputerStateOff : ComputerState
{
    public override void PushOn()
    {
        _computer.TransitionTo(new ComputerStateOn());
    }

    public override void PushOff()
    {
        Console.WriteLine("Computer is already turned off");
    }

    public override void PushSleep()
    {
        Console.WriteLine("Computer must be turned on before it can be put in sleep mode");
    }
}

public class ComputerStateSleep : ComputerState
{
    public override void PushOn()
    {
        _computer.TransitionTo(new ComputerStateOn());
    }

    public override void PushOff()
    {
        _computer.TransitionTo(new ComputerStateOff());
    }

    public override void PushSleep()
    {
        Console.WriteLine("Computer is already asleep");
    }
}
