using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;

using MusicApp.Models;

namespace MusicApp.Controllers.AlbumController
{
    public class AlbumController : Controller
    {
        private readonly MusicDbContext _db;

        public AlbumController(MusicDbContext db)
        {
            _db = db;
        }

        
        

        public IActionResult Index(int artistId)
        {
            
            var artist = _db.Artists.Include(a=>a.Albums).First(a=>a.Id == artistId);

            var model = artist.Albums;
            ViewBag.artistId = artistId;
            return View(model);
            
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Album model)
        {
            
            _db.Albums.Add(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var model = _db.Albums.Find(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int artistId, int id)
        {
            var model = _db.Albums.Find(id);
            ViewBag.artistId = artistId;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int artistId, Album model)
        {
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index),new
            {
                artistid = artistId
            });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _db.Albums.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Album model)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}

