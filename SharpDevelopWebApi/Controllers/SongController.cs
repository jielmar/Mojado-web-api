
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
    	 public IHttpActionResult GetAll(string search = "", string Artist = "" )
    	{
    		List<Song> songs;
    		
    		if(string.IsNullOrWhiteSpace(search)){
    			
    			songs =_db.Songs.ToList();
    		}
    	    else
    		{
    			songs = _db.Songs.Where( x => 
    			                        x.Title.ToLower().Contains(search.ToLower())
    			                        || x.Artist.ToLower().Contains(search.ToLower())
    			                       ).OrderBy(or => or.Title).ToList();
    			
    		}
    	    if(string.IsNullOrWhiteSpace(Artist)){
    	    	songs = songs.Where( x => x.Artist.ToLower() == Artist.ToLower()).ToList();
    	    }
    	    	
    	    	
    	int totalcount = songs.Count();
    	return Ok(new{totalcount, songs});

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
