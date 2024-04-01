using BoardGameStats.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardGameStats.View
{
    /// <summary>
    /// Interakční logika pro PlayerView.xaml
    /// </summary>
    public partial class PlayerView : UserControl
    {
        public PlayerView()
        {
            InitializeComponent();
        }

        private void searchPlayerTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlayerListView.Items.Filter = FilterPlayer;
        }

        private bool FilterPlayer(object obj)
        {
            Player player = (Player)obj;
            return player.Name.Contains(searchPlayerTxt.Text, StringComparison.OrdinalIgnoreCase);
        }
    }
}
