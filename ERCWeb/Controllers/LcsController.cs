using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ERCWeb.Services.Interfaces;
using ERCWeb.Models;

namespace ERCWeb.Controllers
{
    public class LcsController : Controller
    {
        private readonly ILcService _service;

        public LcsController(ILcService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.ShowAll();
            return View(products);
        }

        public async Task<IActionResult> InfoAboutLC(int id) 
        {
            var product = await _service.ShowId(id);
            return View(product);
        }

        public async Task<IActionResult> DeleteLC(int id)
        {
            var product = await _service.DeleteId(id);
            return View(product);
        }

        public IActionResult Edit() 
        {
            return View();
        }

        public async Task<IActionResult> EditId(int id, LcModel model) 
        {
            var product = await _service.EditId(id, model);
            return View(product);
        }
        
        public IActionResult Create() 
        {
            return View();
        }

        public async Task<IActionResult> CreateNew(LcModel lc) 
        {
            var product = await _service.CreateNew(lc);
            return View(product);
        }
    }
}
