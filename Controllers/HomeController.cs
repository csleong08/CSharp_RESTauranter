using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private RESTauranterContext _context;
    
        public HomeController(RESTauranterContext context)
        {
            _context = context;
        }
    
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("create")]
        public IActionResult AddReview(Reviews myReview)
        {
            if(ModelState.IsValid)
            {
                // Reviews NewReview = new Reviews
                myReview.created_at = DateTime.Now;
                myReview.updated_at = DateTime.Now;
                if(DateTime.Today < myReview.visitdate)
                {
                    ModelState.AddModelError("visitdate", "Visit cannot be in the future, nice try!");
                    // TempData["message"] = "LOL, Nice try!";
                    return View("Index");
                }
                _context.Add(myReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpGet("Reviews")]
        public IActionResult Reviews()
        {
            List<Reviews> allReviews = _context.reviews.OrderByDescending(p => p.idreviews).ToList();
            ViewBag.allReviews = allReviews;
            return View("Reviews");
        }
    }
}
