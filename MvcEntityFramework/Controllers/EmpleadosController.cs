using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class EmpleadosController : Controller
    {
        public RepositoryEmpleados repo;
        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;

        }
        public IActionResult Index()
        {
            return View(this.repo.GetEmpleados());
        }
        public IActionResult EmpleadosOficio()
        {
            ViewBag.Oficios = this.repo.GetOficios();
            return View();
        }
        [HttpPost]
        public IActionResult EmpleadosOficio(string oficio)
        {
            ViewBag.Oficios = this.repo.GetOficios();
            return View(this.repo.GetEmpleadosOficio(oficio));
        }

        public IActionResult SubirSalarios(string oficio)
        {
            ViewBag.Oficio = oficio;
            return View();

        }
        [HttpPost]
        public IActionResult SubirSalarios(string oficio, int incremento)
        {

            this.repo.IncrementarSalario(oficio, incremento);
            return RedirectToAction("EmpleadosOficio", new { oficio = oficio });

        }
        public IActionResult EmpleadosDepartamentoLambda()
        {
            return View();

        }
        [HttpPost]
        public IActionResult EmpleadosDepartamentoLambda(int departamento)
        {
            ResumenDepartamento modelo = this.repo.GetResumenDepartamento(departamento);
            return View(modelo);

        }
    }
}
