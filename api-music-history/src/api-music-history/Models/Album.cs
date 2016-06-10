using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_music_history.Models
{
  public class Album
  {
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Artist { get; set; }

    public ICollection<Track> Tracks { get; set; }
  }
}
