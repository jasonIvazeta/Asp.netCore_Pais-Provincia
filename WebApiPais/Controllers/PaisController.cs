using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPais.Models;

namespace WebApiPais.Controllers
{
    [Produces("application/json")]
    [Route("api/Pais")]
    public class PaisController : Controller
    {

        public PaisController(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            return Context.Paises.ToList();
        }

        [HttpGet("{id}", Name = "PaisCreado")]
        public IActionResult GetByID(int id)
        {
            Pais pais = Context.Paises.Include(x => x.Provincias).FirstOrDefault(x => x.id == id);
            if (pais == null)
            {
                return NotFound();
            }
            return Ok(pais);
        }

        [HttpPost]
        public IActionResult CreatePais([FromBody] Pais pais)
        {
            if (ModelState.IsValid)
            {
                Context.Paises.Add(pais);
                Context.SaveChanges();
                return new CreatedAtRouteResult("PaisCreado", new { id = pais.id }, pais);
            }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePais([FromBody] Pais pais, int id)
        {
            if (id != pais.id)
            {
                return BadRequest();
            }
            Context.Entry(pais).State = EntityState.Modified;
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePais(int id)
        {
            Pais pais = Context.Paises.FirstOrDefault(x => x.id == id);
            if (pais == null)
            {
                return NotFound();
            }
            Context.Paises.Remove(pais);
            Context.SaveChanges();
            return Ok(pais);
        }

        

    }
}