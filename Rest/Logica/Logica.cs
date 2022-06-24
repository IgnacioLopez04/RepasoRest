using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Entidades;
using Newtonsoft.Json;
using System.IO;

namespace LogicaNegocio
{
    public class Logica
    {
        #region Singleton

        private static Logica instance = null;

        private Logica() { }

        public static Logica Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logica();
                }
                return instance;
            }
        }
        #endregion
        public void AltaAnimal(Animal animal)
        {
            List<Animal> animales = Json.Instance.Leer();

            if(animales != null)
            {
                animales.Add(new Animal(animales.Count() + 1, animal.Nombre, animal.Especie));

                Json.Instance.Guardar(animales);

            }
            else
            {
                animales = new List<Animal>();
                animales.Add(new Animal(animales.Count() + 1, animal.Nombre, animal.Especie));

                Json.Instance.Guardar(animales);

            }
        }

        public bool ModificarAnimal(Animal animalModificado, int id = 0) 
        {
            List<Animal> animales = Json.Instance.Leer();

            Animal animal = animales.FirstOrDefault(x => x.Id == animalModificado.Id);

            if(animal != null)
            {
                animal.Modificar(animalModificado);

                Json.Instance.Guardar(animales);

                return true;
            }
            return false;
            
        }

        public bool BajaAnimal(int id)
        {
            List<Animal> animales = Json.Instance.Leer();

            Animal animal = animales.FirstOrDefault(x => x.Id == id);
            if (animal != null)
            {
                animal.Eliminado = true;
                Json.Instance.Guardar(animales);

                return true;
            }
            return false;
        }

        public List<Animal> Buscar(int id = 0, string nombre = null, string especie = null)
        {
            List<Animal> animales = Json.Instance.Leer();

            if (id != 0)
                animales = animales.Where(x => x.Id == id).ToList();

            if (nombre != null)
                animales = animales.Where(x => x.Nombre == nombre).ToList();

            if (especie != null)
                animales = animales.Where(x => x.Especie == especie).ToList();

            return animales;
        }
    }
}
