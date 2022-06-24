using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicaNegocio;
using Entidades;

namespace Servicio.Controllers
{
    [RoutePrefix("api/Animal")]
    public class AnimalController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(ConvertirAnimalServicio(Logica.Instance.Buscar()));    
        }

        [Route("Buscar")]
        public IHttpActionResult Get(int id = 0, string nombre = null, string especie = null)
        {

            return Ok(Logica.Instance.Buscar(id, nombre, especie));
        }

        [Route("Cargar")]
        public IHttpActionResult Post(AnimalServicio animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Logica.Instance.AltaAnimal(ConvertirAnimalLogica(animal));

            return Ok();
        }

        public IHttpActionResult Put(int id, AnimalServicio animal) //No funciona, no encuentra el id.
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(Logica.Instance.ModificarAnimal(ConvertirAnimalLogica(animal),id));
        }


        public IHttpActionResult Delete(int id = 0)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(Logica.Instance.BajaAnimal(id));
        }

        private Animal ConvertirAnimalLogica(AnimalServicio animalServicio)
        {
            return new Animal()
            {
                Id = animalServicio.Id,
                Nombre = animalServicio.Nombre,
                Especie = animalServicio.Especie,
                FechaCreacion = animalServicio.FechaCreacion,
                FechaModificacion = animalServicio.FechaModificacion,
                Eliminado = animalServicio.Eliminado
            };
        }

        private List<AnimalServicio> ConvertirAnimalServicio(List<Animal> animalLogica) 
        {
            List<AnimalServicio> animalesServicios = animalLogica.Select(x => new AnimalServicio { Nombre = x.Nombre, Especie = x.Especie,
                Eliminado = x.Eliminado, FechaCreacion = x.FechaCreacion, FechaModificacion = x.FechaModificacion, Id = x.Id}).ToList();

            return animalesServicios;
        }
    }
}
