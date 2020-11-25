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
	/// Description of StudentController.
	/// </summary>
	public class StudentController : ApiController
	{
		SDWebApiDbContext _db = new SDWebApiDbContext();
		
		 [HttpGet]
        public IHttpActionResult GetAll(string keyword = "")
        {
            keyword = keyword.Trim();
            var students = new List<Students>();
            if(!string.IsNullOrEmpty(keyword))
            {
                students = _db.Students
                	.Where(x => x.Lastname.Contains(keyword) || x.Firstname.Contains(keyword))
                	.ToList();
            }
            else
            	students = _db.Students.ToList();

            return Ok(students);
        }
        
         [HttpGet]
        public IHttpActionResult Get(int Id)
        {       
            var student = _db.Students.Find(Id);
            if (student != null)
                return Ok(student);
            else
                return BadRequest("Student not found");
        }
        
         [HttpPost]
        public IHttpActionResult Create(Students newStudents)
        {
        	_db.Students.Add(newStudents);
            _db.SaveChanges();
            return Ok(newStudents);
        }

        [HttpPut]
        public IHttpActionResult Update(Students updatedStudents)
        {
            var student = _db.Students.Find(updatedStudents.Id);
            if (student != null)
            {
                student.Lastname = updatedStudents.Lastname;
                student.Firstname = updatedStudents.Firstname;
                student.SchoolLastAttended = updatedStudents.SchoolLastAttended;
                student.CivilStatus = updatedStudents.CivilStatus;

                _db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(student);
            }
            else
                return BadRequest("Student not found");
        }
        
          [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var student = _db.Students.Find(Id);
            if (student != null)
            {
                _db.Students.Remove(student);
                _db.SaveChanges();
                return Ok("Student successfully deleted");
            }
            else
                return BadRequest("Student not found");
        }
        
        
	}
}