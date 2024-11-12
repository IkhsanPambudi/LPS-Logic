using System;

namespace MemoryLeakExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new EventPublisher();

            int iterations = 0;

            while (iterations < 10)  
            {
                var subscriber = new EventSubscriber(publisher);
                publisher.RaiseEvent();

                subscriber.Dispose();

                iterations++;
            }
        }
    }

    class EventPublisher
    {
        public event EventHandler MyEvent;

        public void RaiseEvent()
        {
            MyEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    class EventSubscriber : IDisposable
    {
        public EventSubscriber(EventPublisher publisher)
        {
            publisher.MyEvent += OnMyEvent;
        }

        private void OnMyEvent(object sender, EventArgs e)
        {
            Console.WriteLine("MyEvent raised");
        }

        public void Dispose()
        { 
            Console.WriteLine("Event handler unsubscribed");
        }
    }
}

alasan : 
1. menghindari memory leak
2. clear code
3. kontrol memory yang lebih baik