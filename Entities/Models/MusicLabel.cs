using System;
using System.Collections.Generic;

namespace probne_kolokwium.Entities.Models
{
    public class MusicLabel
    {
       public int IdMusicLabel { get; set; }
       public string Name { get; set; }
        public virtual IEnumerable<Album> Albums { get; set; }

            }
}
