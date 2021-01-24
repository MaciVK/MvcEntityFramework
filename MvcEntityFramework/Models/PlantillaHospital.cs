using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class PlantillaHospital
    {
        public List<EmpleadoPlantilla> Empleados { get; set; }
        public int NumEmpleados { get; set; }
        public int MaxSalario { get; set; }
        public int MinSalario { get; set; }
    }
}
