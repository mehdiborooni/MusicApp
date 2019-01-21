using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;

namespace MusicApp.Controllers.SongController
{
    public class SongController : Controller
    {
        private readonly MusicDbContext _db;

        public SongController(MusicDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int albumId)
        {
            
            var album = _db.Albums.Include(a => a.Songs).First(a => a.Id == albumId);

            var model = album.Songs;
            ViewBag.albumId = albumId;
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int albumId)
        {
            ViewBag.albumId = albumId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int albumId, Song model)
        {

            var album = _db.Albums.Include(a => a.Songs).First(a => a.Id == albumId);
            album.Songs.Add(model);

            _db.SaveChanges();
            return RedirectToAction(nameof(Index), new
            {
                albumid = albumId
            });
        }

        public IActionResult Details(int id)
        {
            var model = _db.Songs.Find(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _db.Songs.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Song model)
        {
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _db.Songs.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Song model)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}