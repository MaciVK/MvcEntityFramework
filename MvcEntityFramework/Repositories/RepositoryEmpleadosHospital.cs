using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryEmpleadosHospital
    {
        HospitalContext context;
        public RepositoryEmpleadosHospital(HospitalContext context)
        {
            this.context = context;
        }
        public List<EmpleadoHospital> GetEmpleadoHospital()
        {
            var consulta = from all in this.context.EmpleadosHospital
                           select all;
            return consulta.ToList();
        }
        public ProcedimientoEmpleadoHospital GetEmpleadosHospital(int hospitalcod)
        {
            string sql = "PROCEMPLEADOSHOSPITAL @hospitalcod, @suma out, @media out";
            SqlParameter pamhospitalcod = new SqlParameter("@hospitalcod", hospitalcod);
            //LOS PARAMETROS DE SALIDA DEBEN TENER UN VALOR POR DEFECTO PARA PODER EJECUTAR
            //LOS PROCEDIMIENTOS
            SqlParameter pamsuma = new SqlParameter("@suma", -1);
            //TAMBIEN SE INDICA LA DIRECCION DEL PARAMETRO
            pamsuma.Direction = System.Data.ParameterDirection.Output;
            SqlParameter pammedia = new SqlParameter("@media", -1);
            pammedia.Direction = System.Data.ParameterDirection.Output;
            List<EmpleadoHospital> empleados = this.context.EmpleadosHospital
                .FromSqlRaw(sql, pamhospitalcod, pamsuma, pammedia).ToList();
            ProcedimientoEmpleadoHospital salida = new ProcedimientoEmpleadoHospital();
            salida.Empleados = empleados;
            salida.SumaSalarial = Convert.ToInt32(pamsuma.Value);
            salida.MediaSalarial = Convert.ToInt32(pamsuma.Value);


            return salida;
        }

    }
}
