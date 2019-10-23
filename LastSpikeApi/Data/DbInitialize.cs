using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LastSpikeApi.Data
{
    public class DbInitialize
    {
        public DbInitialize (LastSpikeContext context)
        {
            ApplyMigrations (context);
        }

        public void ApplyMigrations (LastSpikeContext context)
        {

            if (context.Database.GetPendingMigrations ().Any ())
            {
                context.Database.Migrate ();
            }
        }
    }
}