﻿using System;
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
  public class TrackController : Controller
  {

    private MusicHistoryContext _context;

    public TrackController(MusicHistoryContext context)
    {
      _context = context;
    }

    // GET: api/track (all tracks)
    // GET: api/track?userId=2 (only tracks matching specified userId)
    [HttpGet]
    public IActionResult Get([FromQuery]int? userId)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IQueryable<object> tracks = from t in _context.Track
                                 join a in _context.Album
                                 on t.AlbumId equals a.AlbumId
                                 select new
                                 {
                                   TrackId = t.TrackId,
                                   Title = t.Title,
                                   AlbumId = t.AlbumId,
                                   AlbumName = a.Title,
                                   ArtistName = a.Artist,
                                   AppUserId = t.AppUserId,
                                   Author = t.Author,
                                   Genre = t.Genre,
                                   Year = a.Year
                                 };


      if (userId != null)
      {
        tracks = from t in _context.Track
                 join a in _context.Album
                 on t.AlbumId equals a.AlbumId
                 where t.AppUserId == userId
                 select new
                 {
                   TrackId = t.TrackId,
                   Title = t.Title,
                   AlbumId = t.AlbumId,
                   AlbumName = a.Title,
                   ArtistName = a.Artist,
                   AppUserId = t.AppUserId,
                   Author = t.Author,
                   Genre = t.Genre,
                   Year = a.Year
                 };
        
      }

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
    public IActionResult Post([FromBody]Track track)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Track.Add(track);
      try
      {
        _context.SaveChanges();
      }
      catch (DbUpdateException)
      {
        if (TrackExists(track.TrackId))
        {
          return new StatusCodeResult(StatusCodes.Status409Conflict);
        }
        else
        {
          throw;
        }
      }
      return CreatedAtRoute("GetTrack", new { id = track.TrackId }, track);
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
