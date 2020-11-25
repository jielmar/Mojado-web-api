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
	/// Description of CourseController.
	/// </summary>
	public class CourseController : ApiController
	{	
		SDWebApiDbContext _db = new SDWebApiDbContext();
		
		[HttpGet]
        public IHttpActionResult GetAll(string keyword = "")
        {
            keyword = keyword.Trim();
            var course = new List<Course>();
            if(!string.IsNullOrEmpty(keyword))
            {
                course = _db.Courses
                	.Where(x => x.Id.Contains(keyword) || x.Name.Contains(keyword))
                	.ToList();
            }
            else
            	course = _db.Courses.ToList();

            return Ok(course);
        }
        
         [HttpGet]
        public IHttpActionResult Get(int Id)
        {       
            var course = _db.Courses.Find(Id);
            if (course != null)
                return Ok(course);
            else
                return BadRequest("course not found");
        }
        
         [HttpPost]
        public IHttpActionResult Create(Course newcourse)
        {
        	_db.Courses.Add(newcourse);
            _db.SaveChanges();
            return Ok(newcourse);
        }

        [HttpPut]
        public IHttpActionResult Update(Course updatedCourses)
        {
            var course = _db.Courses.Find(updatedCourses.Id);
            if (course != null)
            {
                course.Id = updatedCourses.Id;
                course.Name = updatedCourses.Name;
              
              
                _db.Entry(course).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(course);
            }
            else
                return BadRequest("course not found");
        }
        
          [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var course = _db.Courses.Find(Id);
            if (course != null)
            {
                _db.Courses.Remove(course);
                _db.SaveChanges();
                return Ok("Course successfully deleted");
            }
            else
                return BadRequest("Course not found");
        }
	}
}