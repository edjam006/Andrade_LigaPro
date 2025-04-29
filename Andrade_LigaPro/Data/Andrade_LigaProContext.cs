using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Andrade_LigaPro.Models;

namespace Andrade_LigaPro.Data
{
    public class Andrade_LigaProContext : DbContext
    {
        public Andrade_LigaProContext (DbContextOptions<Andrade_LigaProContext> options)
            : base(options)
        {
        }

        public DbSet<Andrade_LigaPro.Models.equipo> equipo { get; set; } = default!;
        public DbSet<Andrade_LigaPro.Models.Jugador> Jugador { get; set; } = default!;
    }
}
