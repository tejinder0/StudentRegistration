using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StudentRegistrationWebApi.Models;

namespace StudentRegistrationWebApi.Controllers
{
    public class StudentRegistrationsController : ApiController
    {
        private StudentDBEntities db = new StudentDBEntities();

        // GET: api/StudentRegistrations
        public IQueryable<StudentRegistration> GetStudentRegistrations()
        {
            return db.StudentRegistrations;
        }

        // GET: api/StudentRegistrations/5
        [ResponseType(typeof(StudentRegistration))]
        public IHttpActionResult GetStudentRegistration(int id)
        {
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return NotFound();
            }

            return Ok(studentRegistration);
        }

        // PUT: api/StudentRegistrations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentRegistration(int id, StudentRegistration studentRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentRegistration.ID)
            {
                return BadRequest();
            }

            db.Entry(studentRegistration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentRegistrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StudentRegistrations
        [ResponseType(typeof(StudentRegistration))]
        public IHttpActionResult PostStudentRegistration(StudentRegistration studentRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentRegistrations.Add(studentRegistration);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentRegistration.ID }, studentRegistration);
        }

        // DELETE: api/StudentRegistrations/5
        [ResponseType(typeof(StudentRegistration))]
        public IHttpActionResult DeleteStudentRegistration(int id)
        {
            StudentRegistration studentRegistration = db.StudentRegistrations.Find(id);
            if (studentRegistration == null)
            {
                return NotFound();
            }

            db.StudentRegistrations.Remove(studentRegistration);
            db.SaveChanges();

            return Ok(studentRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentRegistrationExists(int id)
        {
            return db.StudentRegistrations.Count(e => e.ID == id) > 0;
        }
    }
}