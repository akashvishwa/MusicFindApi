using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicFindApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicApiController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public MusicApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllSongs")]
        public async Task<ActionResult<List<Songs>>> GetSongs()
        {
            var allSongs = await _context.tbl_SongsApi.ToListAsync();

            if (allSongs == null)
                return BadRequest("No Songs Found");

            return Ok(allSongs);

        }

        [Route("/GetSongById/{id}")]
        [HttpGet]
        public async Task<ActionResult<Songs>> GetSongs(int id)
        {
            var idSongs = await _context.tbl_SongsApi.FindAsync(id);

            if (idSongs == null)
                return BadRequest("No Songs Found");

            return Ok(idSongs);

        }

        [HttpPost("CreateSong")]
        public async Task<ActionResult<List<Songs>>> PostAddSong(Songs song) 
        {
            if (song == null) 
            {
                return BadRequest("Please give a song to add");
            }

            await _context.tbl_SongsApi.AddAsync(song);
            await _context.SaveChangesAsync();
            return Ok(await _context.tbl_SongsApi.ToListAsync());
        
        }

        [HttpPut("UpdateSong")]
        public async Task<ActionResult<List<Songs>>> PutUpdateSong(Songs song) 
        {
            var songc = await _context.tbl_SongsApi.FindAsync(song.Id);
            if (songc == null) 
            {
                return BadRequest("Song Not Found");
            }
            
            //change the data
            songc.Name = song.Name;
            songc.Artist = song.Artist;
            songc.Rating = song.Rating;
            songc.Genre = song.Genre;

            await _context.SaveChangesAsync();

            return Ok(await _context.tbl_SongsApi.ToListAsync());

        }

        [HttpDelete("/RemoveSong/{id}")]
        public async Task<ActionResult<List<Songs>>> DeleteSong(int id) 
        {
            var songd= await _context.tbl_SongsApi.FindAsync(id);

            if (songd == null)
                return BadRequest("Song By that id Does not exist");

            _context.tbl_SongsApi.Remove(songd);
            await _context.SaveChangesAsync();
            return Ok(await _context.tbl_SongsApi.ToListAsync());

        }

        

    }
}
