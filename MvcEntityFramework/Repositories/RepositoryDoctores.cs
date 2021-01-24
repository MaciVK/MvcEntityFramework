using Microsoft.EntityFrameworkCore;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryDoctores
    {
        HospitalContext context;
        public RepositoryDoctores(HospitalContext cont)
        {
            this.context = cont;
        }
        public void UpdateEspecialidad(int iddoctor, string esp)
        {
            this.context.ModificarEspecialidad(iddoctor, esp);
        }

        public List<Doctor> GetDoctores()
        {
            string sql = "MostrarDoctores";
            List<Doctor> doctores = this.context.Doctores.FromSqlRaw(sql).ToList();
            return doctores;
        }
        public List<string> GetEspecialidades()
        {
            //PARA LLAMAR A PROCEDIMIENTOS SELECT QUE NO ESTAN MAPEADOS MEDIANTE DbSet
            //HAY QUE HACERLO A LA ANTIGUA Y MAPEAR MANUALMENTE LA RESPUESTA
            //SE USAN OBJ STANDAR DE ADO PERO DE CORE
            //TAMBIEN SE USA LA CONEXION DE LINQ
            using (DbCommand comando = this.context.Database.GetDbConnection().CreateCommand())
            {
                string sql = "Especialidades";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = sql;
                comando.Connection.Open();
                DbDataReader lector = comando.ExecuteReader();
                List<string> especialidades = new List<string>();
                while (lector.Read())
                {
                    especialidades.Add(lector["ESPECIALIDAD"].ToString());
                }
                lector.Close();
                comando.Connection.Close();
                return especialidades;
            }
        }
        public List<Doctor> GetDoctoresByEspecialidad(string esp)
        {
            string sql = "DoctoresEspecialidad @esp";
            SqlParameter pamesp = new SqlParameter("@esp", esp);
            List<Doctor> DoctoresEsp = this.context.Doctores.FromSqlRaw(sql, pamesp).ToList();
            return DoctoresEsp;
        }
        public void UpdateSalarioDoctoresEspecialidad(string esp, int incr)
        {
            string sql = "IncrementoSalarioEspecialidad @especialidad, @incremento";
            SqlParameter pamesp = new SqlParameter("@especialidad", esp);
            SqlParameter pamincr = new SqlParameter("@incremento", incr);
            this.context.Database.ExecuteSqlRaw(sql, pamesp, pamincr);
        }
    }
}
