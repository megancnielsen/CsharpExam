using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CsharpExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CsharpExam.Controllers
{
    public class IdeasController : Controller
    {
        private BeltContext db;
        private int? uid {
            get {
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        public IdeasController(BeltContext context)
        {
            db = context;
        }

        [HttpGet("/dashboard")]
        public IActionResult Dashboard()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Idea> allIdeas = db.Ideas
            .Include(band => band.Likes)
            .ToList();

            return View(allIdeas);
        }

        [HttpGet("/New")]
        public IActionResult New()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost("/Create")]
        public IActionResult Create(Idea newIdea)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                newIdea.UserId =(int)uid;
                db.Add(newIdea);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("New");
        }

        [HttpGet("/idea/{ideaId}/delete")]
        public IActionResult Delete(int ideaId)
        {
            Idea dbIdea = db.Ideas.FirstOrDefault(idea => idea.IdeaId == ideaId);
            db.Ideas.Remove(dbIdea);
            db.SaveChanges();

            return RedirectToAction("Dashboard");
        }
    }
}