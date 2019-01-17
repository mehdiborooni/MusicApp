using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;

namespace MusicApp.Controllers.ArtistController
{
    public class ArtistController : Controller
    {
        private readonly MusicDbContext _db;

        public ArtistController(MusicDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var model = _db.Artists;
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Artist model)
        {

            _db.Artists.Add(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddAlbums()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAlbums(Artist model)
        {

            _db.Artists.Add(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            var model = _db.Artists.Find(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _db.Artists.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Artist model)
        {
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _db.Artists.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Artist model)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}