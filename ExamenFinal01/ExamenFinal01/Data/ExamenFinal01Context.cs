using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenFinal01.Models;

namespace ExamenFinal01.Data
{
    public class ExamenFinal01Context : DbContext
    {
        public ExamenFinal01Context (DbContextOptions<ExamenFinal01Context> options)
            : base(options)
        {
        }

        public DbSet<ExamenFinal01.Models.Catedratico> Catedratico { get; set; }

        public DbSet<ExamenFinal01.Models.Curso> Curso { get; set; }
    }
}
