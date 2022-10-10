using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// Главная идея в том, что когда publisher делает что-то, его subscribers узнают об этом и делают свои действия.

public class Program
{
    public class NotificationArgs: EventArgs
    {
        public readonly string senderId;
        public readonly string receiverId;
        public readonly string Message;

        public NotificationArgs(string senderid, string receiverid, string message)
        {
            senderId = senderid;
            receiverId = receiverid;
            Message = message;
        }
    }

    public class PublisherArgs : EventArgs
    {
        public string Message;
        public PublisherArgs(string message)
        {
            Message = message;
        }
    }

    public sealed class EventBus
    {
        private readonly Dictionary<Publisher, List<Subscriber>> PubSubsDict = new Dictionary<Publisher, List<Subscriber>>();

        public void AddSubtoPub(Publisher pub, Subscriber sub)
        {
            Monitor.Enter(PubSubsDict);
            
            List<Subscriber> subs;
            
            if (PubSubsDict.TryGetValue(pub, out subs)) {
                if (subs == null)
                    subs = new List<Subscriber> { sub };
                else
                    subs.Add(sub);

                PubSubsDict[pub] = subs;
            }
            else
                PubSubsDict.Add(pub, new List<Subscriber>{sub});
            
            Monitor.Exit(PubSubsDict);
        }

        public void RemoveSubFromPub(Publisher pub, Subscriber sub)
        {
            Monitor.Enter(PubSubsDict);
            List<Subscriber> subs;
            if (PubSubsDict.TryGetValue(pub, out subs)) 
            {
                subs?.Remove(sub);
                PubSubsDict[pub] = subs;
            }
            Monitor.Exit(PubSubsDict);
        }

        public void doSomething(Publisher pub, string e_pub, string e_sub)
        {
            Monitor.Enter(PubSubsDict);
            if (!PubSubsDict.ContainsKey(pub))
                return;
            pub.DoSomething(new PublisherArgs(e_pub));
            List<Subscriber> subs;
            if (PubSubsDict.TryGetValue(pub, out subs))
                foreach (var sub in subs)
                    sub.DoSomethingAfterNotification(new NotificationArgs(pub._id, sub._id, e_sub));
            Monitor.Exit(PubSubsDict);
        }
    }

    public class Publisher
    {
        public readonly string _id;
        public event EventHandler<PublisherArgs> PublisherEventHandler = null;
        
        public Publisher(string id)
        {
            _id = id;
        }

        public void DoSomething(PublisherArgs e)
        {
            PublisherEventHandler?.Invoke(this, e);
        }

    }

    public class Subscriber
    {
        public readonly string _id;
        public EventHandler<NotificationArgs> NotificationEvent = null;
        
        public void DoSomethingAfterNotification(NotificationArgs e)
        {
            NotificationEvent?.Invoke(this, e);
        }

        public Subscriber(string id, EventBus event_bus, Publisher pub)
        {
            _id = id;
            event_bus.AddSubtoPub(pub, this);
        }
    }
    
    
    public static void Main()
    {
        var bus = new EventBus();
        var pub1 = new Publisher("Pub 1");
        var pub2 = new Publisher("Pub 2");

        var sub1 = new Subscriber("Sub1", bus, pub1);
        var sub2 = new Subscriber("Sub2", bus, pub1);

        var sub3 = new Subscriber("Sub3", bus, pub2);
        var sub4 = new Subscriber("Sub4", bus, pub2);


        void PrintMessage(object o, PublisherArgs e) => Console.WriteLine(e.Message);

        pub1.PublisherEventHandler += PrintMessage;
        pub2.PublisherEventHandler += PrintMessage;

        void NotificationEvent(object o, NotificationArgs e) => Console.WriteLine("from {0} to {1} message: {2}", e.senderId, e.receiverId, e.Message);

        sub1.NotificationEvent += NotificationEvent;
        sub2.NotificationEvent += NotificationEvent;
        sub3.NotificationEvent += NotificationEvent;
        sub4.NotificationEvent += NotificationEvent;

        bus.doSomething(pub1, "Hello! It's pub1", "I get a notification that pub1 did action.");
        bus.doSomething(pub2, "Good Morning! It's pub2", "I get a notification that pub2 did action.");
        
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        bus.RemoveSubFromPub(pub1, sub2);
        bus.RemoveSubFromPub(pub2, sub3);

        bus.doSomething(pub1, "We lose sub2", "I get a notification that pub1 did action.");
        bus.doSomething(pub2, "We lose sub3", "I get a notification that pub2 did action.");
        
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        
        bus.RemoveSubFromPub(pub1, sub1);
        bus.RemoveSubFromPub(pub2, sub4);
        
        bus.doSomething(pub1, "Pub1: I haven't got any subs", "I get a notification that pub1 did action.");
        bus.doSomething(pub2, "Pub2: I haven't got any subs", "I get a notification that pub2 did action.");
    }
}