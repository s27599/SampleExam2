namespace SampleExam2.Models;

public class Musician
{
    public int idMusician { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
    public ICollection<Song> Songs { get; set; }
}