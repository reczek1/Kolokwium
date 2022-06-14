﻿using System;
using System.Collections.Generic;

namespace probne_kolokwium.Entities.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public virtual IEnumerable<Track> Tracks { get; set; }
        public virtual MusicLabel MusicLabel { get; set; }
    }
}
