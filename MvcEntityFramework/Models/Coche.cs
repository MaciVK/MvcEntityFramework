using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class Coche:ICoche
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Imagen { get; set; }

        public int VelMaxima { get; set; }
        public int VelActual { get; set; }
        public Coche()
        {
            this.VelActual = 0;
            this.Marca = "Lamborghini";
            this.Modelo = "Murciegalo";
            this.VelMaxima = 210;
            this.Imagen = "lamboMurcielago.jpg";

        }

        public void Acelerar()
        {
            this.VelActual += 10;

            if (this.VelActual >= this.VelMaxima)
            {
                this.VelActual = this.VelMaxima;
            }

        }
        public void Frenar()
        {
            this.VelActual -= 10;

            if (this.VelActual < 0)
            {
                this.VelActual = 0;
            }

        }
    }
}
