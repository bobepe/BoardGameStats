﻿using System.Configuration;
using System.Data;
using System.Windows;

namespace BoardGameStats
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var mainView = new MainWindow();
            mainView.Show();
        }
    }

}
