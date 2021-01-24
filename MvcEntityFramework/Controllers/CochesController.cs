using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class CochesController : Controller
    {
        private ICoche car;
        public CochesController(ICoche coche)
        {
            this.car = coche;
        }
        public IActionResult Index()
        {

            return View(this.car);
        }
        [HttpPost]
        public IActionResult Index(string accion)
        {
            if (accion.ToLower() == "acelerar")
            {
                this.car.Acelerar();
            }
            else
            {
                this.car.Frenar();
            }
            return View(this.car);

        }
    }
}
