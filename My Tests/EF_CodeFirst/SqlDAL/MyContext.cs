using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace SqlDAL
{

    public partial class MyContext : DbContext
    {
        public virtual DbSet<Attachments> Attachments { get; set; }

        public MyContext() : base("name=ESERVICES")
        {
        }

        public MyContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
