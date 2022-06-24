using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Eliminado { get; set; }

        public Animal()
        {

        }

        public Animal(int id, string nombre, string especie)
        {
            Id = id;
            Nombre = nombre;
            Especie = especie;
            FechaCreacion = DateTime.Now;
            Eliminado = false;
        }

        public void Modificar(Animal animal)
        {
            Nombre = animal.Nombre;
            Especie = animal.Especie;
            FechaModificacion = DateTime.Now;
        }
    }
}
