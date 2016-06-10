using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api_music_history.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace api_music_history.Controllers
{
  [Route("api/[controller]")]
  [Produces("application/json")]
  [EnableCors("AllowDevelopmentEnvironment")]
  public class AlbumController : Controller
  {
    private MusicHistoryContext _context;

    public AlbumController(MusicHistoryContext context)
    {
      _context = context;
    }

    // GET: api/album
    [HttpGet]
    public IActionResult Get()
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IQueryable<Album> albums = from album in _context.Album
                                        select album;

      return Ok(albums);
    }

    // GET api/album/5 (specific album  by AlbumId)
    [HttpGet("{id}", Name = "GetAlbum")]
    public IActionResult Get(int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      Album album = _context.Album.Single(a => a.AlbumId == id);

      if (album == null)
      {
        return NotFound();
      }

      return Ok(album);
    }

    // POST api/album
    [HttpPost]
    public IActionResult Post([FromBody]Album album)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Album.Add(album);
      try
      {
        _context.SaveChanges();
      }
      catch (DbUpdateException)
      {
        if (AlbumExists(album.AlbumId))
        {
          return new StatusCodeResult(StatusCodes.Status409Conflict);
        }
        else
        {
          throw;
        }
      }
      return CreatedAtRoute("GetAlbum", new { id = album.AlbumId }, album);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

    private bool AlbumExists(int id)
    {
      return _context.Album.Count(album => album.AlbumId == id) > 0;
    }
  }
}
