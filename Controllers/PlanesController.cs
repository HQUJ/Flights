using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flights.Data;
using Flights.Models;

namespace Flights.Controllers
{
    public class PlanesController : Controller
    {
        private readonly FlightsContext _context;
        //malko e promeneno tuk
        //promqna

        public PlanesController(FlightsContext context)
        {
            _context = context;
        }

        // GET: Planes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plane.ToListAsync());
        }

        // GET: Planes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plane = await _context.Plane
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (plane == null)
            {
                return NotFound();
            }

            return View(plane);
        }
        private bool PlaneExists(int id)
        {
            return _context.Plane.Any(e => e.PlaneID == id);
        }
    }
}
