using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions opciones) : base(opciones)
        { }
        //HAY QUE MAPEAR LOS DbSet CADA ENTIDAD PARA QUE SEA ACCESIBLE. OBLIGATORIO PROPIEDADES
        public DbSet<Hospital> Hospitales { get; set; }
        public DbSet<EmpleadoPlantilla> Empleados { get; set; }
        public DbSet<Doctor> Doctores { get; set; }

        public DbSet<EmpleadoHospital> EmpleadosHospital { get; set; }
        //creamos el procedimiento de accion
        public void ModificarEspecialidad(int iddoctor, string esp)
        {
            string sql = "CambiarEspecialidad @iddoctor, @especialidad";
            //necesitamos los params para enviar los datos al procedimiento
            SqlParameter pamid = new SqlParameter("@iddoctor", iddoctor);
            SqlParameter pamesp = new SqlParameter("@especialidad", esp);
            //el objeto context tiene una prop database que es la encargada de ejecutar
            //las consultas de accion
            this.Database.ExecuteSqlRaw(sql, pamid, pamesp);
        }

        public void GetDoctoresByEspecialidad(string esp)
        {
            string sql = "DoctoresEspecialidad @esp";
            SqlParameter pamesp = new SqlParameter("@esp", esp);
            this.Database.ExecuteSqlRaw(sql, pamesp);
        }


    }
}
