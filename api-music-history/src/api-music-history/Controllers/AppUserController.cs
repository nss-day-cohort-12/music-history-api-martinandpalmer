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
  public class AppUserController : Controller
  {

    private MusicHistoryContext _context;

    public AppUserController(MusicHistoryContext context)
    {
      _context = context;
    }

    // GET: api/appuser
    [HttpGet]
    public IActionResult Get()
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IQueryable<AppUser> users = from au in _context.AppUser
                                 select au;

      return Ok(users);
    }

    // GET api/appuser/5 (specific user  by AppUserId)
    [HttpGet("{id}", Name = "GetUser")]
    public IActionResult Get(int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      AppUser appUser = _context.AppUser.Single(au => au.AppUserId == id);

      if (appUser == null)
      {
        return NotFound();
      }

      return Ok(appUser);
    }

    // POST api/appuser
    [HttpPost]
    public IActionResult Post([FromBody]AppUser appUser)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.AppUser.Add(appUser);
      try
      {
        _context.SaveChanges();
      }
      catch (DbUpdateException)
      {
        if (AppUserExists(appUser.AppUserId))
        {
          return new StatusCodeResult(StatusCodes.Status409Conflict);
        }
        else
        {
          throw;
        }
      }
      return CreatedAtRoute("GetUser", new { id = appUser.AppUserId }, appUser);
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

    private bool AppUserExists(int id)
    {
      return _context.AppUser.Count(appUser => appUser.AppUserId == id) > 0;
    }

  }
}
