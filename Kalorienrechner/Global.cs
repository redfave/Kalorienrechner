using CaloryLibrary.Repository;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorienrechner
{
    public static class Global
    {
        public static int CurrentUserID
        {
            get;
            set;
        }



        public static bool ConnectionEstablished
        {
            get;
            set;
        }
    }
}
