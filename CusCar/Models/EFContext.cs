using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CusCar.Models
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("name=ConnectionString")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Complain> Complains { get; set; }

        public DbSet<ComplainDetail> ComplainDetails { get; set; }

        public DbSet<ComplainStatusMaster> ComplainStatusMasters { get; set; }
    }
}