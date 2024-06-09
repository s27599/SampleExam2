namespace SampleExam2.Models;

public class Song
{
    public int IdSong { get; set; }
    public string Title { get; set; }
    public float Duration { get; set; }
    // public int IdAlbum { get; set; }
    public ICollection<Musician> Musicians { get; set; }
}