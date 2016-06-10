using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_music_history.Models
{
  public class Track
  {
    [Key]
    public int TrackId { get; set; }
    public int AlbumId { get; set; }
    public int AppUserId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }

    // [ForeignKey("AlbumId")]
    public Album Album { get; set; }

    // [ForeignKey("AppUserId")]
    public AppUser AppUser { get; set; }
  }
}
