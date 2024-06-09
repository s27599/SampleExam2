namespace SampleExam2.Models;

public class Album
{
    public int IdAlbum { get; set; }
    public string AlbumName { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Label Label { get; set; }
    
    public ICollection<Song> Songs { get; set; }
}