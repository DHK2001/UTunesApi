using Microsoft.AspNetCore.Mvc;
using UTunes.Core;
using UTunes.Core.Entities;

namespace UTunes.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController : ControllerBase
{
    private readonly IRepository<Song> repository;

    public SongController(IRepository<Song> repository)
    {
        this.repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> GetSongs()
    {
        var songs = await this.repository.AllAsync();

        return Ok(songs.Select(x => new SongDto
        {
            Id = x.Id,
            Name = x.Name,
            Artist= x.Artist,
            AlbumId= x.AlbumId,
            Price = x.Price
        }));

    }

    [HttpGet("albums/{id}/[controller]")]
    public async Task<IActionResult> GetSongId([FromRoute] int id) { 

        var songsAlbum = this.repository.Filter(x => x.AlbumId == id);

        return Ok(songsAlbum.Select(x => new SongDto
        {
            Id = x.Id,
            Name = x.Name,
            Artist = x.Artist,
            AlbumId = x.AlbumId,
            Price = x.Price
        }));

    }
}

