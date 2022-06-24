using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Servicio.Controllers
{
    public class AnimalServicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El especie es obligatorio.")]
        public string Especie { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Eliminado { get; set; }

        public AnimalServicio()
        {

        }

        public AnimalServicio(string nombre, string especie)
        {
            Nombre = nombre;
            Especie = especie;
        }
    }
}