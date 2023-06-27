using Firma.Data.Data.CMS;
using Firma.Data.Data.Kino;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data
{
    public class FirmaContext : DbContext
    {
        //klasa firmacontext reprezentuje cala baze danych
        public FirmaContext(DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public DbSet<Strona> Strona { get; set; } 

        public DbSet<Komentarz>? Komentarz { get; set; }

        public DbSet<Kategorie>? Kategorie { get; set; }

        public DbSet<Posty>? Posty { get; set; }

        public DbSet<Szczegoly>? Szczegoly { get; set; }

        public DbSet<Filmy>? Filmy { get; set; }

        public DbSet<Gatunek>? Gatunek { get; set; }
        public DbSet<Oferty>? Oferty { get; set; }
        public DbSet<Prezenty>? Prezenty { get; set; }
        public DbSet<Prywatnosc>? Prywatnosc { get; set; }
        public DbSet<ONas>? ONas { get; set; }
        public DbSet<StronaGlowna>? StronaGlowna { get; set; }
        public DbSet<Bilet>? Bilet { get; set; }
        public DbSet<Miejsce>? Miejsce { get; set; }

    }
}
