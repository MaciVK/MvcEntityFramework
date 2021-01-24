using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public interface ICoche
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Imagen { get; set; }
        public int VelMaxima { get; set; }
        public int VelActual { get; set; }
        void Acelerar();
        void Frenar();
    }
}
