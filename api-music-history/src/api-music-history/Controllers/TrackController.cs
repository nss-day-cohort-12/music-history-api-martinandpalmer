using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api_music_history.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace api_music_history.Controllers
{
  [Route("api/[controller]")]
  [Produces("application/json")]
  [EnableCors("AllowDevelopmentEnvironment")]
  public class TrackController : Controller
  {

    private MusicHistoryContext _context;

    public TrackController(MusicHistoryContext context)
    {
      _context = context;
    }

    // GET: api/track
    [HttpGet]
    public IActionResult Get()
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IQueryable<Track> tracks = from t in _context.Track
                                 select t;

      return Ok(tracks);
    }

    // GET api/track/5 (specific track  by TrackId)
    [HttpGet("{id}", Name = "GetTrack")]
    public IActionResult Get(int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      Track track = _context.Track.Single(t => t.TrackId == id);

      if (track == null)
      {
        return NotFound();
      }

      return Ok(track);
    }

    // POST api/track
    [HttpPost]
    public void Post([FromBody]string value)
    {

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

    private bool TrackExists(int id)
    {
      return _context.Track.Count(t => t.TrackId == id) > 0;
    }
  }
}
