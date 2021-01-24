using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Repositories
{
    public class RepositoryEnfermos
    {
        private EnfermosContext context;
        public RepositoryEnfermos(EnfermosContext context)
        {
            this.context = context;
        }
        public List<Enfermo> GetEnfermos()
        {
            var consulta = from enfermos in this.context.Enfermos
                           select enfermos;
            return consulta.ToList();
        }
        public Enfermo BuscarEnfermo(int inscripcion)
        {
            var consulta = from enfermo in this.context.Enfermos
                           where enfermo.Inscripcion == inscripcion
                           select enfermo;
            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.First();
            }

        }
        public List<Genero> GetGeneros()
        {
            var consulta = (from sexo in this.context.Enfermos
                            select sexo.Sexo).Distinct();
            List<Genero> generos = new List<Genero>();
            foreach (string dato in consulta)
            {
                Genero gen = new Genero();
                gen.Value = dato;
                if (dato.ToLower() == "f")
                {
                    gen.Text = "FEMENINO";
                }
                else
                {
                    gen.Text = "MASCULINO";
                }
                generos.Add(gen);
            }
            return generos;
        }

        public List<Enfermo> GetEnfermosByGenero(string genero)
        {
            var consulta = from enfermos in this.context.Enfermos
                           where enfermos.Sexo == genero
                           select enfermos;
            return consulta.ToList();
        }
        public void DeleteEnfermo(int inscripcion)
        {
            //CREAS LA ENTIDAD (ENFERMO)
            Enfermo enf = this.BuscarEnfermo(inscripcion);
            //EL CONTEXTO, AL HEREDAR DE DbSet TIENE UN METODO .Remove(Enfermo entity);
            this.context.Enfermos.Remove(enf);
            //PARA QUE EN LA BBDD SE GUARDEN LOS CAMBIOS, HAY QUE HACER UN SaveChanges();
            this.context.SaveChanges();
        }
        public void InsertEnfermo(int inscripcion, string apellido, string direccion, DateTime fechanac, string genero
            , string nss)
        {
            //SE CREA UN NUEVO OBJETO   
            Enfermo enf = new Enfermo();
            enf.Inscripcion = inscripcion;
            enf.Apellido = apellido;
            enf.Direccion = direccion;
            enf.FechaNacimiento = fechanac;
            enf.Sexo = genero;
            enf.NSS = nss;
            this.context.Enfermos.Add(enf);
            this.context.SaveChanges();
        }
        public void ModificarEnfermo(int inscripcion, string apellido, string direccion, DateTime fechanac, string genero
            , string nss)
        {
            //SE CREA UN NUEVO OBJETO   
            Enfermo enf = this.BuscarEnfermo(inscripcion);
            enf.Inscripcion = inscripcion;
            enf.Apellido = apellido;
            enf.Direccion = direccion;
            enf.FechaNacimiento = fechanac;
            enf.Sexo = genero;
            enf.NSS = nss;
            this.context.SaveChanges();
        }
    }
}
