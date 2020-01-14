using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreVS2.Data;
using DotNetCoreVS2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreVS2.Controllers
{
    [Route("site/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IRepositorio _repo;

        public EventoController(IRepositorio repo)
        {
            _repo = repo;
        }


        // GET: api/Evento
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _repo.GetAllEventos();
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Evento/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var eventos = await _repo.GetEventosById(id);
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // POST: api/Evento
        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                    return Ok("Evento Adicionado");
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível adicionar o envento. Confira a Sintaxi.");
            }
            return BadRequest("Não Salvou.");
        }

        // PUT: api/Evento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {

                var evento = await _repo.GetEventosById(id);
                if(evento!=null)
                {
                    _repo.Update(model);
                    if (await _repo.SaveChangesAsync())
                        return Ok("Evento atualizado");

                }
            }
            catch (Exception)
            {

                return BadRequest("Não Atualizado Excessão.");
            }
            return BadRequest("Não Atualizado");

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _repo.GetEventosById(id);
                if (evento != null)
                {
                    _repo.Delete(evento);
                    if (await _repo.SaveChangesAsync())
                        return Ok("Evento Deletado");

                }
            }
            catch (Exception)
            {

                return BadRequest("Não Deletado Excessão.");
            }
            return BadRequest("Não Atualizado");
        }
    }
}
