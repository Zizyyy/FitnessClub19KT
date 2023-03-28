using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FitnessClub19KT.DB;
using FitnessClub19KT.Windows;
using FitnessClub19KT.Pages;

namespace FitnessClub19KT.ClassHelper
{
    public class EFClass
    {
        public static Entities context { get; set; } = new Entities();
    }
}
