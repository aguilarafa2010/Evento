using DotNetCoreVS2.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace DotNetCoreVS2.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
    }
}
