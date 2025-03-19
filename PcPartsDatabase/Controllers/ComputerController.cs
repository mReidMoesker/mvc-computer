using Microsoft.AspNetCore.Mvc;
using PcPartsDatabase.BLL;
using PcPartsDatbase.Models;

namespace PcPartsDatabase.Controllers
{
    public class ComputerController : Controller
    {
        private readonly ComputerService _computerService;

        public ComputerController(ComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var computers = _computerService.GetAllComputers();
            return View(computers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return View(computer);
            }

            _computerService.AddComputer(computer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var computer = _computerService.GetComputer(id);

            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        [HttpPost]
        public IActionResult Edit(int id, Computer computer)
        {
            if (id != computer.SystemID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(computer);
            }

            try
            {
                _computerService.UpdateComputer(computer);
            }
            catch (Exception ex)
            {
                if (!_computerService.ComputerExists(computer.SystemID))
                {
                    return NotFound();
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
