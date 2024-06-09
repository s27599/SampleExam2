namespace SampleExam2.Models;

public class Label
{
    public int IdLabel { get; set; }
    public string Name { get; set; }
    
    public ICollection<Album> Albums { get; set; }
}