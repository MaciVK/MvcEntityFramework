using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryEnfermos repo;
        public EnfermosController(RepositoryEnfermos repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View(this.repo.GetEnfermos());
        }
        public IActionResult Details(int idinscripcion)
        {
            return View(this.repo.BuscarEnfermo(idinscripcion));
        }
        public IActionResult EnfermosGenero(string genero)
        {
            List<Genero> Generos = this.repo.GetGeneros();
            ViewBag.Generos = Generos;
            //HAY QUE ENVIAR DOS CARACTERISTICAS
            //ENVIAMOS LOS GENEROS
            //AL RECIBIR UN GENERO, ENVIAMOS LOS ENFERMOS
            if (genero != null)
            {
                List<Enfermo> enfermos = this.repo.GetEnfermosByGenero(genero);
                return View(enfermos);
            }
            return View();
        }
        public IActionResult EliminarEnfermo(int inscripcion)
        {
            this.repo.DeleteEnfermo(inscripcion);
            return RedirectToAction("Index");
        }
        public IActionResult NuevoEnfermo()
        {
            return View(this.repo.GetGeneros());
        }
        [HttpPost]
        public IActionResult NuevoEnfermo(int inscripcion, string apellido, string direccion, DateTime fechanac
            , string genero
            , string nss)
        {
            this.repo.InsertEnfermo(inscripcion, apellido, direccion, fechanac, genero, nss);
            return RedirectToAction("Details", new { idinscripcion=inscripcion});
        }
        public IActionResult ModificarEnfermo(int inscripcion)
        {
            ViewBag.Generos = this.repo.GetGeneros();
            Enfermo enf = this.repo.BuscarEnfermo(inscripcion);
            return View(enf);

        }
        [HttpPost]
        public IActionResult ModificarEnfermo(Enfermo enfermo)
        {
            ViewBag.Generos = this.repo.GetGeneros();
            this.repo.ModificarEnfermo(enfermo.Inscripcion, enfermo.Apellido, enfermo.Direccion, enfermo.FechaNacimiento
                , enfermo.Sexo, enfermo.NSS);

            return RedirectToAction("Details", new { idinscripcion = enfermo.Inscripcion});

        }
    }
}
