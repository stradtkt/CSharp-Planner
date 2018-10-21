using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.Models;

namespace Planner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingContext _wContext;
        public WeddingController(WeddingContext context)
        {
            _wContext = context;
        }
        private User ActiveUser 
        {
            get 
            {
                return _wContext.users.Where(u => u.user_id == HttpContext.Session.GetInt32("user_id")).FirstOrDefault();
            }
        }
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Login", "User");
            }
            List<Wedding> weddings = _wContext.weddings
                .Include(u => u.User)
                .Include(g => g.Guests)
                .ToList();
            ViewBag.user = ActiveUser;
            ViewBag.weddings = weddings;
            return View();
        }
        [HttpGet("Dashboard/AddWedding")]
        public IActionResult AddWedding() 
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.user = ActiveUser;
            return View();
        }
        [HttpPost("PostWedding")]
        public IActionResult PostWedding(PostWedding wed)
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Login", "User");
            }
            if(ModelState.IsValid)
            {
                if(wed.event_date < DateTime.Now) 
                {
                    ModelState.AddModelError("event_date", "I am sorry you cannot add something that was in the past");
                    return RedirectToAction("Dashboard", "Wedding");
                }
                Wedding wedding = new Wedding 
                {
                    wedding_id = wed.wedding_id,
                    wedder_one = wed.wedder_one,
                    wedder_two = wed.wedder_two,
                    location = wed.location,
                    event_date = wed.event_date
                };
                _wContext.weddings.Add(wedding);
                _wContext.SaveChanges();
                return RedirectToAction("Dashboard", "Wedding");
            }
            return View("AddWedding");
        }

        [HttpGet("Dashboard/Wedding/{wedding_id}")]
        public IActionResult Wedding(int wedding_id) 
        {
            if(ActiveUser == null) 
            {
                return RedirectToAction("Login", "User");
            }
            Wedding wedding = _wContext.weddings
                .Include(u => u.User)
                .Include(g => g.Guests)
                .Where(w => w.wedding_id == wedding_id)
                .SingleOrDefault();
            List<Guest> guests = _wContext.guests
                .Include(w => w.Wedding)
                .Include(u => u.User)
                .ToList();
            ViewBag.wedding = wedding;
            ViewBag.guests = guests;
            ViewBag.user = ActiveUser;
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
