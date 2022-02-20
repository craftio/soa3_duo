using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    class OrderNotifier : IObserver<Order>
    {
        private IDisposable unsubscriber;
        private string name;

        public OrderNotifier(string name)
        {
            this.name = name;
        }

        public virtual void Subscribe(IObservable<Order> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public void OnCompleted()
        {
            Console.WriteLine("The order notifier has completed transmitting data to {0}.", name);
            Unsubscribe();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("{0}: The order cannot be determined.", name);
        }

        public void OnNext(Order order)
        {
            Console.WriteLine("Order #{1}: The current order costs €{0}", order.CalculatePrice(), order.GetOrderNr());
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
