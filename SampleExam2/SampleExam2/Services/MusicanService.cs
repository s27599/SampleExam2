using Microsoft.EntityFrameworkCore;
using SampleExam2.Models;
using SampleExam2.Models.DTOs;

namespace SampleExam2.Services;

public class MusicianService: IMusicianService
{
    private readonly MusicianDbContext _context;

    public MusicianService(MusicianDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> DoesMusicanExists(int id)
    {
        var musican = await _context.Musicians.FindAsync(id);
        return musican != null;
    }

    public async Task<MusicianSongsDTO> GetMusicianSongs(int id)
    {
        var musician =  await _context.Musicians
            .Include(m => m.Songs)
            .FirstAsync(m => m.idMusician == id);

        var newsongs = await _context.Songs.Include(s => s.Musicians)
            .Where(s => s.Musicians.Contains(musician) )
            .Select(s => new SongDTO {IdSong = s.IdSong,
            Title = s.Title, Duration = s.Duration} ).ToListAsync();
        var response = new MusicianSongsDTO
        {
            FirstName = musician.FirstName
            , LastName = musician.LastName
            , nickname = musician.Nickname,
            Songs = newsongs
        };
        
        return response;
            
    }

    public async Task<Musician> AddMusician(AddMusicanDTO addMusicanDto)
    {
        var musician = new Musician
        {
            FirstName = addMusicanDto.FirstName,
            LastName = addMusicanDto.LastName,
            Nickname = addMusicanDto.Nickname
        };

        if (addMusicanDto.Title.Length > 0)
        {
            var song = await _context.Songs.
                Where(s => s.Title == addMusicanDto.Title && s.Duration == addMusicanDto.Duration)
                .FirstOrDefaultAsync();
            if (song == null)
            {
                song = new Song { Title = addMusicanDto.Title, Duration = addMusicanDto.Duration };
                _context.Songs.Add(song);
            }
            musician.Songs = new List<Song> { song };
        }

        _context.Musicians.Add(musician);
        await _context.SaveChangesAsync();
        return musician;
    }
}