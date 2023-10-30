using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class FlightsController : Controller

    {
       
        private readonly ApplicationDbContext _context;

        public FlightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Privacy()
        {
            var flights = _context.Flights.ToList();
            return View(flights); 
        }
    }
}
