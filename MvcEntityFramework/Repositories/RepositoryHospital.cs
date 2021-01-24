using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryHospital
    {
        //ESTA CLASE ES LA QUE SE ENCARGA DE REALIZAR LAS CONSULTAS A LAS BBDD 
        //MEDIANTE LINQ TO EF
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }
        public List<Hospital> GetHospitales()
        {
            var consulta = from hospitales in this.context.Hospitales
                           select hospitales;
            return consulta.ToList();
        }
        
    }
}
