using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GLFadiou.Models
{
    public class GlFadiouContext : DbContext
    {
        public GlFadiouContext() : base("Conn")
        {

        }

        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<Lit> Lits { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Infirmier> Infirmiers { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        
    }
}