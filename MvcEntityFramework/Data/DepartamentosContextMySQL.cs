using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MvcEntityFramework.Data
{
    public class DepartamentosContextMySQL : IDepartamentosContext
    {
        private MySqlDataAdapter adapterDept;
        private DataTable tablaDept;

        public DepartamentosContextMySQL(string cadena)
        {
            this.adapterDept = new MySqlDataAdapter("SELECT * FROM DEPT", cadena);
            this.tablaDept = new DataTable();
            this.adapterDept.Fill(tablaDept);

        }
        public List<Departamento> GetDepartamentos()
        {
            var consulta = from departamentos in this.tablaDept.AsEnumerable()
                           select departamentos;
            List<Departamento> departs = new List<Departamento>();
            foreach (var row in consulta)
            {
                Departamento dep = new Departamento();
                dep.Numero = row.Field<int>("DEPT_NO");
                dep.Nombre = row.Field<string>("DNOMBRE");
                dep.Localidad = row.Field<string>("LOC");
                departs.Add(dep);
            }
            return departs;
        }
    }
}
