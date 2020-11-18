
using SharpDevelopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


	
    public class SongController : ApiController
    {
        [Route("api/song/getsong")]
        [HttpGet]
        public IHttpActionResult GeySong()
        {

            var mySong = new Song();
            mySong.Id = 1;
            mySong.Title = "hello my love";
            mySong.Artist = "westlife";
            mySong.Genre = "pop";
            

            return BadRequest("eror");
        }
    
        [Route("api/song/")]
        [HttpGet]
        public IHttpActionResult GetSongs()
        {
            var songs = new List<Song>();

            var song1 = new Song();
            song1.Id = 1;
            song1.Title = "welcome to my paradise";
            song1.Artist = "bob marley";
            song1.Genre = "slow rock";
            songs.Add(song1);

            var mySong = new Song();
            mySong.Id = 1;
            mySong.Title = "hello my love";
            mySong.Artist = "westlife";
            mySong.Genre = "pop";
            songs.Add(mySong);

           

            return Ok(songs);
        }

    }
