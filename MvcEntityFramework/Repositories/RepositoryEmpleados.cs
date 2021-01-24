using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryEmpleados
    {
        EmpleadosContext context;
        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }
        public List<Empleado> GetEmpleados()
        {
            var consulta = from empleados in this.context.Empleados
                           select empleados;
            return consulta.ToList();
        }
        public List<string> GetOficios()
        {
            var consulta = (from oficios in this.context.Empleados
                            select oficios.Oficio).Distinct();
            return consulta.ToList();
        }
        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from empleados in this.context.Empleados
                           where empleados.Oficio.ToLower() == oficio.ToLower()
                           select empleados;
            return consulta.ToList();
        }
        public void IncrementarSalario(string oficio, int incremento)
        {
            var consulta = from empleados in this.context.Empleados
                           where empleados.Oficio.ToLower() == oficio.ToLower()
                           select empleados;
            foreach(Empleado emp in consulta.ToList())
            {
                emp.Salario += incremento;
            }
            this.context.SaveChanges();


        }
        public ResumenDepartamento GetResumenDepartamento(int deptno)
        {
            //MALA PRAXIS, PERO SE HARÁ PARA LAMBDA
            List<Empleado> empleados = this.GetEmpleados();
            //Se aplica el filtro con Lambda
            List<Empleado> filtro = empleados.Where(x => x.Departamento == deptno).ToList();
            //Capturamos con Lambda los datos del conjunto
            if (filtro.Count() == 0)
            {
                return null;
            }
            int personas = filtro.Count();
            int max = filtro.Max(x => x.Salario);
            int min = filtro.Min(x => x.Salario);
            ResumenDepartamento resumen = new ResumenDepartamento();
            resumen.Empleados = filtro;
            resumen.Personas = personas;
            resumen.MaxSalario = max;
            resumen.MinSalario = min;
            return resumen;
        }
    }
}
