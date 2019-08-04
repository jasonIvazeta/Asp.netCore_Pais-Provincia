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
    [Route("api/Pais/{PaisId}/Provincia")]
    public class ProvinciaController : Controller
    {

        public ProvinciaController(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        [HttpGet]
        public IEnumerable<Provincia> GetAll(int PaisId)
        {
            return Context.Provincias.Where(x => x.PaisId == PaisId).ToList();
        }

        [HttpGet("{id}", Name = "GetProvincia")]
        public IActionResult GetByID(int id)
        {
            Provincia provincia = Context.Provincias.Where(x => x.id == id).FirstOrDefault();
            if (provincia == null)
            {
                return NotFound();
            }
            return Ok(provincia);
        }

        [HttpPost]
        public IActionResult CreateProvincia([FromBody] Provincia provincia, int PaisId)
        {
            provincia.PaisId = PaisId;
            if (ModelState.IsValid)
            {
                Context.Provincias.Add(provincia);
                Context.SaveChanges();
                return new CreatedAtRouteResult("GetProvincia", new { id = provincia.id }, provincia);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProvincia([FromBody] Provincia provincia, int id)
        {
            if (provincia.id == id)
            {
                Context.Entry(provincia).State = EntityState.Modified;
                Context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProvincia(int id)
        {
            Provincia provincia = Context.Provincias.Where(x => x.id == id).FirstOrDefault();
            if (provincia != null)
            {
                Context.Provincias.Remove(provincia);
                Context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

    }
}