using System.ComponentModel.DataAnnotations;

namespace MusicFindApi.Model
{
    public class Songs
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }

        public string Rating { get; set; }

        public string Genre { get; set; }

        public string Lyrics { get; set; }

        public string Link { get; set; }


    }
}
