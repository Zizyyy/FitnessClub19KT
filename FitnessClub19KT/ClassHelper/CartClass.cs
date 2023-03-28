using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FitnessClub19KT.DB;

namespace FitnessClub19KT.ClassHelper
{
    internal class CartClass
    {
        public static ObservableCollection<ServiceCart> serviceCart = new ObservableCollection<ServiceCart>();
        static CartClass()
        {
            
        }
        public static void AddToList(ServiceCart sc)
        {
            if (serviceCart.Contains(sc))
            {
                serviceCart.FirstOrDefault(x => x == sc).Count++;
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
