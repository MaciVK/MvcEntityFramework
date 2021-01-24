using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryPlantilla
    {
        HospitalContext context;
        public RepositoryPlantilla(HospitalContext context)
        {
            this.context = context;
        }
        public List<EmpleadoPlantilla> GetEmpleadosHospital(int hospitalcod)
        {
            var consulta = from empleados in this.context.Empleados
                           select empleados;
            return consulta.ToList();
        }
    }
}
