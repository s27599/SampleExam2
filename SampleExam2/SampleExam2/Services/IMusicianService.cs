using SampleExam2.Models;
using SampleExam2.Models.DTOs;

namespace SampleExam2.Services;

public interface IMusicianService
{
    Task<bool> DoesMusicanExists(int id);
    Task<MusicianSongsDTO> GetMusicianSongs(int id);
    Task<Musician> AddMusician(AddMusicanDTO addMusicanDto);
}