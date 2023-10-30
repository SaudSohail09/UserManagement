using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class PassengersController : Controller
    {
        private readonly ApplicationDbContext _contextabc;

        public PassengersController(ApplicationDbContext contextabc)
        {
            _contextabc = contextabc;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult About()
        {
            var passengers = _contextabc.Passengers.ToList();
            return View(passengers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> Add([Bind("PassengerID,FirstName,LastName,DateOfBirth,PassportID,ContactInformation")]Passengers Passengers)
        {
            if (ModelState.IsValid)
            {
                _contextabc.Passengers.Add(Passengers);
                await _contextabc.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Add");
            }
            }
    }
}
