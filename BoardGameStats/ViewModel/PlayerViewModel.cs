using BoardGameStats.Database;
using BoardGameStats.Model;
using BoardGameStats.View.Players;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BoardGameStats.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        private PlayerRepository _playerRepository;

        public ObservableCollection<Player> AllPlayers { get; set; }
        public string Name { get; set; }

        // commands
        public ICommand ShowWindowCommand { get; set; }
        public ICommand AddPlayerCommand { get; set; }

        public PlayerViewModel()
        {
            _playerRepository = new PlayerRepository();
            //AllPlayers = _playerRepository.GetAll();
            AllPlayers = new ObservableCollection<Player>();
            for (int i = 0; i < 1000000; i++)
                AllPlayers.Add(new Player() { Id = i, Name = $"player {i}" });

            ShowWindowCommand = new ViewModelCommand(ShowWindow, CanShowWindow);
            AddPlayerCommand = new ViewModelCommand(AddPlayer);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            EditPlayerWindow edit = new EditPlayerWindow();
            edit.Show();
        }

        private void AddPlayer(object obj)
        {
            _playerRepository.Add(new Player() { Name = Name });
        }
    }
}
