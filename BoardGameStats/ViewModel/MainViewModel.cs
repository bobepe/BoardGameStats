using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoardGameStats.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        public ViewModelBase CurrentChildView
        {
            get { return _currentChildView; }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        private IconChar _icon;
        public IconChar Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        // Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowPlayViewCommand { get; }
        public ICommand ShowGameViewCommand { get; }
        public ICommand ShowPlayerViewCommand { get; }

        public MainViewModel()
        {
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowPlayViewCommand = new ViewModelCommand(ExecuteShowPlayViewCommand);
            ShowGameViewCommand = new ViewModelCommand(ExecuteShowGameViewCommand);
            ShowPlayerViewCommand = new ViewModelCommand(ExecuteShowPlayerViewCommand);

            ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void ExecuteShowPlayViewCommand(object obj)
        {
            CurrentChildView = new PlayViewModel();
            Caption = "Partie";
            Icon = IconChar.Trophy;
        }

        private void ExecuteShowGameViewCommand(object obj)
        {
            CurrentChildView = new GameViewModel();
            Caption = "Hry";
            Icon = IconChar.BoxArchive;
        }

        private void ExecuteShowPlayerViewCommand(object obj)
        {
            CurrentChildView = new PlayerViewModel();
            Caption = "Hráči";
            Icon = IconChar.UserGroup;
        }
    }
}
