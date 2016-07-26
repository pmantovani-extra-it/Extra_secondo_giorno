using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace App2.ViewModels
{
    public class UserViewModel: ViewModelBase
    {
        public string Name { get; set; }
        public  string Surname { get; set; }
    }
}
