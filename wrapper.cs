using System;

namespace main
{
    public abstract class Notifier
    {
        public abstract string Send();
    }

    class Notification : Notifier
    {
        public override string Send()
        {
            return "A notification message";
        }
    }

    abstract class Decorator : Notifier
    {
        protected Notifier _notifier;

        public Decorator(Notifier notifier)
        {
            this._notifier = notifier;
        }

        public void SetNotifier(Notifier notifier)
        {
            this._notifier = notifier;
        }

        public override string Send()
        {
            if (this._notifier != null)
            {
                return this._notifier.Send();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    class SMSDecorator : Decorator
    {
        public SMSDecorator(Notifier ntf) : base(ntf)
        {
        }

       public override string Send()
        {
            return $"SMS({base.Send()})";
        }
    }

    class FBDecorator : Decorator
    {
        public FBDecorator(Notifier ntf) : base(ntf)
        {
        }

        public override string Send()
        {
            return $"FB({base.Send()})";
        }
    }
    
    class SlackDecorator : Decorator
    {
        public SlackDecorator(Notifier ntf) : base(ntf)
        {
        }

        public override string Send()
        {
            return $"Slack({base.Send()})";
        }
    }
    
    public class Client
    {
        public void ClientCode(Notifier notifier)
        {
            Console.WriteLine("RESULT: " + notifier.Send());
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            var simple = new Notification();
            Console.WriteLine("Client: I get a simple notification:");
            client.ClientCode(simple);
            Console.WriteLine();

            SMSDecorator sms = new SMSDecorator(simple);
            FBDecorator fb = new FBDecorator(sms);
            SlackDecorator slack = new SlackDecorator(simple);
            Console.WriteLine("Client: Now I will receive both sms and facebook notification:");
            client.ClientCode(fb);
            Console.WriteLine("Client: And then I will receive a slack notification:");
            client.ClientCode(slack);
        }
    }
}
