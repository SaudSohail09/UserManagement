
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _contextab;

        public BookingsController(ApplicationDbContext contextab)
        {
            _contextab = contextab;
        }
        [Authorize]
        public IActionResult Index()
        {
            var bookings = _contextab.Bookings.ToList();
            return View(bookings);
           
        }
        

    
    }
}
