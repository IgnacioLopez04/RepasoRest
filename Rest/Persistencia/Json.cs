using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Entidades;

namespace Persistencia
{
    public class Json
    {
        string path = @"C:\Users\ignac\OneDrive\Universidad\3er año\Programación II\PracticasParcial\Rest\Json\Animales.txt";

        #region Singleton

        private static Json instance = null;

        private Json() { }

        public static Json Instance 
        { 
            get 
            { 
                if (instance == null) 
                { 
                    instance = new Json(); 
                }
                return instance; 
            } 
        }

        #endregion
        public void Guardar(List<Animal> animales)
        {
            VerificarFile(path);

            using(StreamWriter write = new StreamWriter(path, false))
            {
                string json = JsonConvert.SerializeObject(animales);
                write.Write(json);
            }
        }

        public List<Animal> Leer()
        {
            VerificarFile(path);

            using(StreamReader read = new StreamReader(path))
            {
                return JsonConvert.DeserializeObject<List<Animal>>(read.ReadToEnd());
            }
        }

        private bool VerificarFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                return true;
            }

            return false;
        }
    }
}
