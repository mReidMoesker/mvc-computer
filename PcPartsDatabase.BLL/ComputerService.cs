using Microsoft.EntityFrameworkCore;
using PcPartsDatabase.DAL;
using PcPartsDatbase.Models;

namespace PcPartsDatabase.BLL
{
    public class ComputerService
    {
        private readonly PcPartsDatabaseDbContext _context;

        public ComputerService(PcPartsDatabaseDbContext context)
        {
            _context = context;
        }

        public List<Computer> GetAllComputers()
        {
            return _context.Computers
                .Include(c => c.Processor)
                .Include(c => c.GraphicsCard)
                .Include(c => c.Storage)
                .Include(c => c.OperatingSystems)
                .ToList();
        }

        public Computer GetComputer(int id)
        {
            return _context.Computers
                .Include(c => c.Processor)
                .Include(c => c.GraphicsCard)
                .Include(c => c.Storage)
                .Include(c => c.OperatingSystems)
                .FirstOrDefault(c => c.SystemID == id);
        }

        public void AddComputer(Computer computer)
        {
            _context.Add(computer);
            _context.SaveChanges();
        }

        public void UpdateComputer(Computer computer)
        {
            _context.Update(computer);
            _context.SaveChanges();
        }

        public void RemoveComputer(Computer computer)
        {
            _context.Remove(computer);
            _context.SaveChanges();
        }

        public bool ComputerExists(int id)
        {
            return _context.Computers.Any(c => c.SystemID == id);
        }
    }
}
