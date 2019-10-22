using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using LastSpikeApi.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace LastSpikeApi.Data
{
    public class LastSpikeContext : DbContext
    {
        public DbSet<User> Users {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql("server=127.0.0.1;database=last_spike;user=spikeuser;password=spikepassword;");
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<User> (entity =>
            {
                entity.HasKey (e => e.UserID);
                entity.Property (e => e.Latitude);
                entity.Property (e => e.Longitude);
                entity.Property (e => e.Name);
            });

            IEnumerable<User> users = LoadJson();

            modelBuilder.Entity<User>().HasData(users);
        }

        public IEnumerable<User> LoadJson ()
        {
            using (StreamReader r = new StreamReader ("Data/data.json"))
            {
                string json = r.ReadToEnd ();
                IEnumerable<User> items = JsonConvert.DeserializeObject<List<User>> (json);
                return items;
            }
        }
    }
}
