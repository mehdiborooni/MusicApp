using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Data;

namespace MusicApp.Controllers
{
    public class AlbumController : Controller
    {
        private readonly MusicDbContext _db;

        public AlbumController(MusicDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}