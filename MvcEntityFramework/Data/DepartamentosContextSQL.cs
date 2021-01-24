using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MvcEntityFramework.Data
{
    public class DepartamentosContextSQL : IDepartamentosContext
    {
        private SqlDataAdapter adaptadorDept;
        private DataTable tablaDept;

        public DepartamentosContextSQL(string cadena)
        {
            //string cadena = "Data Source=LOCALHOST;Initial Catalog=HOSPITAL;User ID=SA;Password=MCSD2020";
            this.tablaDept = new DataTable();
            this.adaptadorDept = new SqlDataAdapter("SELECT * FROM DEPT", cadena);
            this.adaptadorDept.Fill(tablaDept);
        }
        public List<Departamento> GetDepartamentos()
        {
            var consulta = from depart in this.tablaDept.AsEnumerable()
                           select depart;
            List<Departamento> departamentos = new List<Departamento>();
            if (consulta.Count() != 0)
            {
                foreach (var row in consulta)
                {
                    Departamento dept = new Departamento();
                    dept.Localidad = row.Field<string>("LOC");
                    dept.Numero = row.Field<int>("DEPT_NO");
                    dept.Nombre = row.Field<string>("DNOMBRE");
                    departamentos.Add(dept);
                }

            }
            return departamentos;
        }
    }
}
