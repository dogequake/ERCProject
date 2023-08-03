using ERCWeb.Models;
using ERCWeb.Services;
using ERCWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ERCWeb.Controllers
{
    public class ResidentController : Controller
    {
        private readonly IResidentService _service;

        public ResidentController(IResidentService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateNew(ResidentModel resident)
        {
            var product = await _service.CreateNew(resident);
            return View(product);
        }
    }
}
