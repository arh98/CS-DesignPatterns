using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator;

//component interface
public interface IMailService {
    bool SendMail(string message);
}

//concrete component
public class CloudMailService : IMailService {
    public bool SendMail(string message) {

        Console.WriteLine($"sending message : \"{message}\" - via {nameof(CloudMailService)}");
        return true;
    }
}

//concrete component 2
public class OnPremiseMailService : IMailService {
    public bool SendMail(string message) {

        Console.WriteLine($"sending message : \"{message}\" - via {nameof(OnPremiseMailService)}");
        return true;
    }
}

// decorator
public abstract class MailServiceDecoratorBase : IMailService {
    private readonly IMailService _mailService;
    public MailServiceDecoratorBase(IMailService mailService) {
        _mailService = mailService;
    }
    public virtual bool SendMail(string message) {
        return _mailService.SendMail(message);
    }
}

//concrete decorator
public class StatisticsDecorator : MailServiceDecoratorBase {
    public StatisticsDecorator(IMailService mailService) : base(mailService) {
    }
    public override bool SendMail(string message) {
        Console.WriteLine($"Collecting Statistics in {nameof(StatisticsDecorator)} ...");
        return base.SendMail(message);
    }
}
//concrete decorator 2
public class MessageDBDecorator : MailServiceDecoratorBase {
    public List<string> SentMessagesDB { get; private set; }
    public MessageDBDecorator(IMailService mailService) : base(mailService) {
        SentMessagesDB = new List<string>();
    }
    public override bool SendMail(string message) {
        if (base.SendMail(message)) {
            SentMessagesDB.Add(message);
            return true;
        }
        return false;
    }
}