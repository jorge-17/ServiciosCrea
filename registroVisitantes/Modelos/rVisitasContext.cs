using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using registroVisitantes.Modelos;

namespace registroVisitantes.Modelos
{
    public class rVisitasContext : DbContext
    {
        public rVisitasContext(DbContextOptions<rVisitasContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> rV_Empleados { get; set; }
        public DbSet<Visitante> rV_Visitantes { get; set; }
        public DbSet<Visita> rV_Visitas { get; set; }
        public DbSet<TipoVisitante> rV_TipoVisitantes { get; set; }
    }
}
