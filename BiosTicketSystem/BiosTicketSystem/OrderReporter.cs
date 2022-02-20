using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class OrderReporter : IObservable<Order>
    {
        private List<IObserver<Order>> observers;

        public OrderReporter()
        {
            observers = new List<IObserver<Order>>();
        }

        public IDisposable Subscribe(IObserver<Order> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }
    }

    class Unsubscriber : IDisposable
    {
        private List<IObserver<Order>> observers;
        private IObserver<Order> observer;

        public Unsubscriber(List<IObserver<Order>> observers, IObserver<Order> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            if (observer != null && observers.Contains(observer))
                observers.Remove(observer);
        }
    }

}
