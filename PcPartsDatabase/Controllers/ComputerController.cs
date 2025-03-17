using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcPartsDatabase.DAL;
using PcPartsDatbase.Models;

namespace PcPartsDatabase.Controllers
{
    public class ComputerController : Controller
    {
        private readonly PcPartsDatabaseDbContext _context;

        public ComputerController(PcPartsDatabaseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Computer> computers = _context.Computers.Include(c => c.Processor).Include(c => c.GraphicsCard).Include(c => c.Storage).Include(c => c.OperatingSystems).ToList();
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
                return View();
            }

            _context.Add(computer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
