using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPais.Models
{
    public class Pais
    {
        public Pais()
        {
            Provincias = new List<Provincia>();
        }

        public int id { get; set; }
        [StringLength(30)]
        public string nombre { get; set; }
        public List<Provincia> Provincias { get; set; }
    }
}
