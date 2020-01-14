using DotNetCoreVS2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreVS2.Data
{
    //Declaração da interface
    public interface IRepositorio 
    {
        void Add<T>(T entitt) where T : class;
        void Update<T>(T entitt) where T : class;
        void Delete<T>(T entitt) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Evento[]> GetAllEventos();
        Task<Evento> GetEventosById(int id);
        Task<Evento[]> GetEventosByName(string nome);

    }
}
