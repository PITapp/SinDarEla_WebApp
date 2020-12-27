using System;
using Microsoft.AspNetCore.Mvc;

namespace SinDarEla.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
