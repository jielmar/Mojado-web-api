using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SharpDevelopWebApi.Models;
namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of FacultyController.
	/// </summary>
	public class FacultyController :ApiController
	{
		SDWebApiDbContext _db = new SDWebApiDbContext();
		
		[HttpGet]
        public IHttpActionResult GetAll(string keyword = "")
        {
            keyword = keyword.Trim();
            var faculty = new List<Faculty>();
            if(!string.IsNullOrEmpty(keyword))
            {
                faculty = _db.Faculties
                	.Where(x => x.SSSNumber.Contains(keyword) || x.Supervisor.Contains(keyword))
                	.ToList();
            }
            else
            	faculty = _db.Faculties.ToList();

            return Ok(faculty);
        }
        
         [HttpGet]
        public IHttpActionResult Get(int Id)
        {       
            var faculty = _db.Faculties.Find(Id);
            if (faculty != null)
                return Ok(faculty);
            else
                return BadRequest("Faculty not found");
        }
        
         [HttpPost]
        public IHttpActionResult Create(Faculty newfaculty)
        {
        	_db.Faculties.Add(newfaculty);
            _db.SaveChanges();
            return Ok(newfaculty);
        }

        [HttpPut]
        public IHttpActionResult Update(Faculty updatedFaculty)
        {
            var faculty = _db.Faculties.Find(updatedFaculty.SSSNumber);
            if (faculty != null)
            {
                faculty.SSSNumber = updatedFaculty.SSSNumber;
                faculty.Supervisor = updatedFaculty.Supervisor;
              
              
                _db.Entry(faculty).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(faculty);
            }
            else
                return BadRequest("Faculty not found");
        }
        
          [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var faculty = _db.Faculties.Find(Id);
            if (faculty != null)
            {
                _db.Faculties.Remove(faculty);
                _db.SaveChanges();
                return Ok("Faculty successfully deleted");
            }
            else
                return BadRequest("Faculty not found");
        }
	}
}