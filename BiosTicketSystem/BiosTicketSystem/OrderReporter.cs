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
        private List<IObserver<Order>> _observers;
        private IObserver<Order> _observer;

        public Unsubscriber(List<IObserver<Order>> observers, IObserver<Order> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }

}
