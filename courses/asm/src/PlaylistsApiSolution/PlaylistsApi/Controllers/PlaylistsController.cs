using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaylistsApi.Data;
using System.ComponentModel.DataAnnotations;

namespace PlaylistsApi.Controllers;

[ApiController]
public class PlaylistsController : ControllerBase
{
    private readonly PlaylistsDataContext _context;

    public PlaylistsController(PlaylistsDataContext context)
    {
        _context=context;
    }

    [HttpGet("playlists")]
    public async Task<ActionResult<GetPlaylistResponse>> GetPlayLists([FromQuery] int delaySeconds = 0)
    {
        if(delaySeconds > 0)
        {
            await Task.Delay(delaySeconds * 1000);
        }
        var data = await _context.Playlists!
            .Select(p => new PlaylistItemViewModel(p.Id.ToString(), p.Title, p.Artist, p.Album, p.YearReleased))
            .ToListAsync();
        return Ok(new GetPlaylistResponse(data));
    }

    [HttpPost("playlists")]
    public async Task<ActionResult<PlaylistItemViewModel>> Add([FromBody] PlaylistCreate request, [FromQuery] int delaySeconds = 0)
    {
        if(delaySeconds > 0)
        {
            await Task.Delay(delaySeconds * 1000);
        }
        var item = new PlaylistItem
        {
            Title = request.Title,
            Artist = request.Artist,
            Album = request.Album,
            YearReleased = request.YearReleased,
        };
        _context.Playlists!.Add(item);
        await _context.SaveChangesAsync();

        var response = new PlaylistItemViewModel(item.Id.ToString(), item.Title, item.Artist, item.Album, item.YearReleased);

        return StatusCode(201, response);
    }

    [HttpDelete("playlists/{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var saved = await _context.Playlists!.SingleOrDefaultAsync(p => p.Id == id);
        if(saved != null)
        {
            _context.Playlists!.Remove(saved);
            await _context.SaveChangesAsync();

        }

        return NoContent();
    }
}


public record PlaylistItemViewModel(string id, string title, string? artist, string? album, int? yearReleased);
public record GetPlaylistResponse(IList<PlaylistItemViewModel> data);

public record PlaylistCreate
{
    [Required]
    public string Title { get; init; } = String.Empty;
    public string? Artist { get; init; }
    public string? Album { get; init; }
    public int? YearReleased { get; init; }
}