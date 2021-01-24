using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class ResumenDepartamento
    {
        public List<Empleado> Empleados { get; set; }
        public int Personas { get; set; }
        public int MaxSalario { get; set; }
        public int MinSalario { get; set; }

    }
}
