using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using FitnessClub19KT.DB;

namespace FitnessClub19KT.ClassHelper
{
    internal class CartClass
    {
        public static ObservableCollection<ServiceCart> serviceCart = new ObservableCollection<ServiceCart>();
        public class Cart
        {
            public int Id { get; set; }
            public virtual ICollection<ServiceCart> CartItems { get; set; }
        }

        public class CartItem
        {
            public int CartId { get; set; }
            public Cart Cart { get; set; }
        }

            public static void AddToList(ServiceCart sc)
        {
            var target = serviceCart.FirstOrDefault(x => x.IdService == sc.IdService);
            if (target!=null)
            {
                target.Count++;
                return;
            }
            serviceCart.Add(sc);
        }
    }
    public class ServiceCart : Service
    {
        public ServiceCart(Service service)
        {
            this.IdService = service.IdService;
            this.Title = service.Title;
            this.Cost = service.Cost;
            this.Description = service.Description;
            this.OrderService = service.OrderService;
            this.DurationInMin = service.DurationInMin;
        }
        public int Count { get; set; } = 1;
    }
}
