using Bglobal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bglobal.Data
{
    public class BglobalContext : DbContext
    {
        private string ConnectionString
        {
            get
            {
                return "Data Source=DESKTOP-IBHL9MB\\SQLEXPRESS;database=BglobalABM;User Id=sa;Password=123;Persist Security Info=True;";
            }
        }
        public BglobalContext() : base()
        {
            this.Database.Connection.ConnectionString = this.ConnectionString;
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}
