using Agenciadeviagem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenciadeviagem.Data
{
    public class AgenciaDeViagemContext: DbContext
    {
        public AgenciaDeViagemContext(DbContextOptions<AgenciaDeViagemContext>opt):
            base(opt)

        { }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Home> Home { get; set; }


    }
}
