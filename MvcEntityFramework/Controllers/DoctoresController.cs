using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctores repo;
        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }
        public IActionResult UpdateEspecialidadDoctor()
        {
            return View();

        }
        [HttpPost]
        public IActionResult UpdateEspecialidadDoctor(int iddoctor, string esp)
        {
            this.repo.UpdateEspecialidad(iddoctor, esp);
            List<Doctor> doctores = this.repo.GetDoctores();
            return RedirectToAction("Index");
        }
        public IActionResult DoctoresByEsp()
        {

            ViewBag.Esp = this.repo.GetEspecialidades();
            return View(this.repo.GetDoctores());
        }
        [HttpPost]
        public IActionResult DoctoresByEsp(string esp, int incr)
        {
            ViewBag.Esp = this.repo.GetEspecialidades();
            this.repo.UpdateSalarioDoctoresEspecialidad(esp, incr);
            return View(this.repo.GetDoctoresByEspecialidad(esp));
        }
    }
}
