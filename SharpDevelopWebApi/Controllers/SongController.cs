
using SharpDevelopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


	
    public class SongController : ApiController
    {
    	SDWebApiDbContext _db  = new SDWebApiDbContext();
    	
    	[HttpGet]
    	public IHttpActionResult GetAll(){
    		
    		List<Song> songs =_db.Songs.ToList();
    		return Ok(songs);
    	}
    	[HttpGet]
    	public IHttpActionResult Get (int Id){
    		
    		var song  = _db.Songs.Find(Id);
    		if (song != null){
    			return Ok(song);
    		}
    		else{
    			return BadRequest("Song not found");
    		}
    	}
    	
    	
    	public IHttpActionResult Create([FromBody]Song song){
    		_db.Songs.Add(song);
    		_db.SaveChanges();
    		return Ok(song.Id);
    	}
    	[HttpPut]
    	public IHttpActionResult Update([FromBody]Song updatedsong){
    		var song = _db.Songs.Find(updatedsong.Id);
    		if ( song != null){
    			song.Artist = updatedsong.Artist;
    		song.Title = updatedsong.Title;
    		song.Genre = updatedsong.Genre;
    		_db.Entry (song).State = System.Data.Entity.EntityState.Modified;	
    		_db.SaveChanges();
    		
    		return Ok(song);
    		}
    		else{
    			return BadRequest("error");
    		}
    	}
    	[HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var song = _db.Songs.Find(Id);
            if (song != null)
            {
                _db.Songs.Remove(song);
                _db.SaveChanges();
                return Ok("Song successfully deleted");
            }
            else{
               return BadRequest("songs not found");
            }
              
        }
        
    }
