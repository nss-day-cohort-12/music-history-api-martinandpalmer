using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_music_history.Models
{
  public class AppUser
  {
    public int AppUserId { get; set; }
    public int TrackId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public ICollection<Track> Tracks { get; set; }
  }
}
