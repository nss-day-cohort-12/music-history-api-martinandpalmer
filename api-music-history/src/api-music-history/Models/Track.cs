using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_music_history.Models
{
  public class Track
  {
    public int TrackId { get; set; }
    public int AlbumId { get; set; }
    public int AppUserId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }

    public Album Album { get; set; }
    public AppUser AppUser { get; set; }
  }
}
