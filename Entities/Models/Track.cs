using System.Collections.Generic;

namespace probne_kolokwium.Entities.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int? IdAlbum { get; set; } //PRZEZ TEN ZNAK ZAPYTANIA GODZINE SIEDZIAŁEM NAD ZADANIEM PODDAJE SIE I TAK NIE ZDAZE :DDD
        public virtual IEnumerable<Musician_Track> Musician_Tracks { get; set; }
        public virtual Album Album { get; set; }
    }
}
