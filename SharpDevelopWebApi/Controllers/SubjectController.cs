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
	/// Description of SubjectController.
	/// </summary>
	public class SubjectController : ApiController
	{
		SDWebApiDbContext _db = new SDWebApiDbContext();
		
		[HttpGet]
        public IHttpActionResult GetAll(string keyword = "")
        {
            keyword = keyword.Trim();
            var subject = new List<Subject>();
            if(!string.IsNullOrEmpty(keyword))
            {
                subject = _db.Subjects
                	.Where(x => x.Code.Contains(keyword) || x.DescriptiveTitle.Contains(keyword))
                	.ToList();
            }
            else
            	subject = _db.Subjects.ToList();

            return Ok(subject);
        }
        
         [HttpGet]
        public IHttpActionResult Get(int Id)
        {       
            var subject = _db.Subjects.Find(Id);
            if (subject != null)
                return Ok(subject);
            else
                return BadRequest("Subject not found");
        }
        
         [HttpPost]
        public IHttpActionResult Create(Subject newSubject)
        {
        	_db.Subjects.Add(newSubject);
            _db.SaveChanges();
            return Ok(newSubject);
        }

        [HttpPut]
        public IHttpActionResult Update(Subject updatedSubject)
        {
            var subject = _db.Subjects.Find(updatedSubject.Id);
            if (subject != null)
            {
                subject.Id = updatedSubject.Id;
                subject.Code = updatedSubject.Code;
                subject.DescriptiveTitle = updatedSubject.DescriptiveTitle;
              
              
                _db.Entry(subject).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(subject);
            }
            else
                return BadRequest("Subject not found");
        }
        
          [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var subject = _db.Subjects.Find(Id);
            if (subject != null)
            {
                _db.Subjects.Remove(subject);
                _db.SaveChanges();
                return Ok("Subject successfully deleted");
            }
            else
                return BadRequest("Subject not found");
        }
	}
}