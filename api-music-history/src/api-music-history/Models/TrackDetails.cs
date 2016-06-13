using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_music_history.Models
{
  public class TrackDetails
  {
    public int TrackId { get; set; }
    public string Title { get; set; }
    public int AlbumId { get; set; }
    public string AlbumName { get; set; }
    public string ArtistName { get; set; }
    public int AppUserId { get; set; }
    public string Username { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
  }
}
