using BoardGameStats.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameStats.Database
{
    public class PlayerRepository
    {
        private static ObservableCollection<Player> DatabaseUser = new ObservableCollection<Player>();

        public void Add(Player player)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    DatabaseUser.Add(player);
                    db.Player.Add(player);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add player");
            }
        }

        public void Edit(Player player)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    Player p = db.Player.FirstOrDefault(i => i.Id == player.Id);
                    if (p != null)
                    {
                        p.Name = player.Name;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to edit player");
            }
        }

        public ObservableCollection<Player> GetAll()
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    DatabaseUser.Clear();
                    List<Player> result = db.Player.ToList();
                    foreach (var i in result)
                        DatabaseUser.Add(i);

                    return DatabaseUser;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all players");
            }
        }

        public Player GetById(int id)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    return db.Player.FirstOrDefault(i => i.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get player");
            }
        }
    }
}
