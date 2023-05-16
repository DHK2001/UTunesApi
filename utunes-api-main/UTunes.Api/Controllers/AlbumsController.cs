using Microsoft.AspNetCore.Mvc;
using UTunes.Core;
using UTunes.Core.Entities;

namespace UTunes.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : ControllerBase
{
    private readonly IRepository<Album> repository;

    public AlbumsController(IRepository<Album> repository)
    {
        this.repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAlbums() {
        var albums = await this.repository.AllAsync();

        return Ok(albums.Select(x => new AlbumDto
        {
            Id = x.Id,
            Name = x.Name,
            Artist = x.Artist,
            Review = x.Review,
            Likes = x.Likes
        }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAlbumsId([FromRoute] int id)
    {
        var album = this.repository.GetById(id);

        return Ok(new AlbumDto
        {
            Id = album.Id,
            Name = album.Name,
            Artist = album.Artist,
            Review = album.Review,
            Likes = album.Likes
        });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAlbun(int id, [FromBody] AlbumCreateDto album)
    {

        return Ok(repository.Update(new Album
        {
            Id = id,
            Name = album.Name,
            Artist = album.Artist,
            Review = album.Review,
            Likes = album.Likes
        }));

    }
}

