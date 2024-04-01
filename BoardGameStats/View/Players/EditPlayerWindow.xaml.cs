using BoardGameStats.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BoardGameStats.View.Players
{
    /// <summary>
    /// Interakční logika pro EditPlayerWindow.xaml
    /// </summary>
    public partial class EditPlayerWindow : Window
    {
        public EditPlayerWindow()
        {
            InitializeComponent();
            PlayerViewModel playerViewModel = new PlayerViewModel();
            this.DataContext = playerViewModel;
        }
    }
}
