using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPais.Models
{
    public class Provincia
    {
        //model
        public int id { get; set; }
        public string nombre { get; set; }
        [ForeignKey("Pais")]
        public int PaisId { get; set; }
        [JsonIgnore]
        public Pais pais { get; set; }
    }
}
