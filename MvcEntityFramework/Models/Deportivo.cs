using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class Deportivo : Coche, ICoche
    {
        public Deportivo(string marca, string modelo, string imagen, int velmax)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Imagen = imagen;
            this.VelMaxima = velmax;
            this.VelActual = 0;
        }
        public Deportivo()
        {
            this.Marca = "Mitsubishi";
            this.Modelo = "Lancer Evolution";
            this.VelMaxima = 240;
            this.VelActual = 0;
            this.Imagen = "Lancer.jpg";
        }

    }
}
