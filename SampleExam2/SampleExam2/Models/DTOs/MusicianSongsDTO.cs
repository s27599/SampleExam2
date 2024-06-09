namespace SampleExam2.Models.DTOs;

public class MusicianSongsDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? nickname { get; set; }
    public List<SongDTO> Songs { get; set; }
}