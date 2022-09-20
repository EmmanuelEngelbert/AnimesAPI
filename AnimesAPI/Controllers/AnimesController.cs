using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimesAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController : Controller
    {
        private static List<Animes> animes = new List<Animes>
        {
                new Animes
                {
                    Id = 1,
                    AnimeTitle = "One Piece",
                    YearOfProduction = 1999,
                    AnimeGenre = "Shonen",
                    AnimeStudio = "Toei"
                },

                 new Animes
                {
                    Id = 2,
                    AnimeTitle = "Naruto",
                    YearOfProduction = 2002,
                    AnimeGenre = "Shonen",
                    AnimeStudio = "Pierrot"
                }
            };

        [HttpGet] // GET: /<controller>/

        public async Task<ActionResult<List<Animes>>> GetAllAnimes() //allows for the schema to be visible within swagger
        {
            return Ok(animes);
        }

        [HttpGet("{id}")] // GET one anime

        public async Task<ActionResult<Animes>> GetOneAnime(int id) //allows for the schema to be visible within swagger
        {
            var anime = animes.Find(h => h.Id == id);
            if (anime == null)
                return BadRequest("Hero not found.");
            return Ok(anime);
        }

        [HttpPost]
        public async Task<ActionResult<List<Animes>>> AddAnime(Animes anime)
        {
            animes.Add(anime);
            return Ok(animes);
        }

        [HttpPut]
        public async Task<ActionResult<List<Animes>>> UpdateAnime(Animes request)
        {
            var anime = animes.Find(h => h.Id == request.Id);
            if (anime == null)
                return BadRequest("Anime not found.");
            anime.AnimeTitle = request.AnimeTitle;
            anime.YearOfProduction = request.YearOfProduction;
            anime.AnimeGenre = request.AnimeGenre;
            anime.AnimeStudio = request.AnimeStudio;
            return Ok(animes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Animes>>> DeleteOneAnime(int id)
        {
            var anime = animes.Find(h => h.Id == id);
            if (anime == null)
                return BadRequest("Anime not found.");
            animes.Remove(anime);
            return Ok(animes);
        }
    }
}

