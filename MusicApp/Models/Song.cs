﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Song
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public Album Album { get; set; }


    }
}
