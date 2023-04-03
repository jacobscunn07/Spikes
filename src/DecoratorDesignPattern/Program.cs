Console.WriteLine("**********");
var notification = new EmailNotification();
Console.WriteLine("Before Decoration:");
Console.WriteLine(notification.Notify());

Console.WriteLine();

var signatureDecorator = new SignatureDecorator(notification);
Console.WriteLine("Signature Decoration - Decorating the email notification");
Console.WriteLine(signatureDecorator.Notify());

Console.WriteLine();

var encryptionDecorator = new EncryptionDecorator(signatureDecorator);
Console.WriteLine("Encryption Decoration - Decorating the previous decorated object (signature decorator)");
Console.WriteLine(encryptionDecorator.Notify());

Console.WriteLine("**********");

public abstract class Notification
{
    public abstract string Notify();
} 

public class EmailNotification : Notification
{
    public override string Notify()
    {
        return GetType().Name;
    }
}

public abstract class NotificationDecorator : Notification
{
    private readonly Notification _notification;

    protected NotificationDecorator(Notification notification)
    {
        _notification = notification;
    }

    public override string Notify()
    {
        return _notification == null ? string.Empty : _notification.Notify();
    }
}

public class SignatureDecorator : NotificationDecorator
{
    public SignatureDecorator(Notification notification) : base(notification)
    {
    }

    public override string Notify()
    {
        return $"{GetType().Name}({base.Notify()})";
    }
}

public class EncryptionDecorator : NotificationDecorator
{
    public EncryptionDecorator(Notification notification) : base(notification)
    {
    }

    public override string Notify()
    {
        return $"{GetType().Name}({base.Notify()})";
    }
}
