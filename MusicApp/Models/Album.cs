using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Album
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int Year { get; set; }
        public IList<Song> Songs { get; set; }

        
    }
}
