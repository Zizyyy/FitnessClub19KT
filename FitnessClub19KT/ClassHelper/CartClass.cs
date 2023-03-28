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
    }
    public class ServiceCart : Service
    {
        public int Count { get; set; } = 1;
    }
}
