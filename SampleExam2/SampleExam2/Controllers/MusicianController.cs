using Microsoft.AspNetCore.Mvc;
using SampleExam2.Models;
using SampleExam2.Models.DTOs;
using SampleExam2.Services;

namespace SampleExam2.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MusicianController: ControllerBase
{
    private readonly IMusicianService _musicianService;
    
    public MusicianController(IMusicianService musicianService)
    {
        _musicianService = musicianService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMusicanWithSongs(int id)
    {
        if (!await _musicianService.DoesMusicanExists(id))
        {
            return BadRequest("Musican does not exist");
        }
        
        return Ok(await _musicianService.GetMusicianSongs(id));
        
    }
    
    [HttpPost]
    
    public async Task<IActionResult> AddMusician( AddMusicanDTO addMusicanDto)
    {
        await _musicianService.AddMusician(addMusicanDto);
        return Created();
    }
    
    
    
    
}