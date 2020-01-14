using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetCoreVS2.Model;

namespace DotNetCoreVS2.Data
{
    public class Repositorio : IRepositorio
    {
        private readonly Contexto _context;

        public Repositorio(Contexto contexto)
        {
            _context = contexto;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento[]> GetAllEventos()
        {
            IQueryable<Evento> query = _context.Eventos;
            query = query.AsNoTracking().OrderBy(h => h.EventoId);
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventosById(int id)
        {
            IQueryable<Evento> query = _context.Eventos;
            query = query.AsNoTracking().OrderBy(h => h.EventoId);

            return await query.FirstOrDefaultAsync(h => h.EventoId == id);
        }

        public async Task<Evento[]> GetEventosByName(string nome)
        {
            IQueryable<Evento> query = _context.Eventos;
            query = query.AsNoTracking()
                .Where(h => h.Tema.Contains(nome))
                .OrderBy(h => h.EventoId); ;

            return await query.ToArrayAsync();
        }

        

        
    }
}
