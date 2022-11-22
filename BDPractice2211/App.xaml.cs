using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BDPractice2211.ADOApp;

namespace BDPractice2211
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static BDPractice2211Entities Connection = new BDPractice2211Entities();
    }
}
