namespace probne_kolokwium.Entities.Models
{
    public class Musician_Track
    {
        public int IdMusician;
        public int IdTrack;
        public virtual Musician Musician { get; set; }
        public virtual Track Track { get; set; }
    }
}
