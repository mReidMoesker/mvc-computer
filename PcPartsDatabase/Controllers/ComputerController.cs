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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Computer computer = _context.Computers.Find(id);
            
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

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computer);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (!_context.Computers.Any(e => e.SystemID == computer.SystemID))
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
            return View(computer);
        }
    }
}
