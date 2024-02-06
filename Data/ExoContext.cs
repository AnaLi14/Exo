using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exo.Models;

namespace Exo.Data
{
    public class ExoContext : DbContext
    {
        public ExoContext (DbContextOptions<ExoContext> options)
            : base(options)
        {
        }

        public DbSet<Exo.Models.Exo> Exo { get; set; } = default!;
    }
}
