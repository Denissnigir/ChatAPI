using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using ChatAPI.Classes;
using ChatAPI.Model;
using ChatAPI.Models;
using Newtonsoft.Json;

namespace ChatAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private ChatBDEntities db = new ChatBDEntities();

        [ResponseType(typeof(List<ResponseEmployee>))]
        // GET: api/Employees
        public IHttpActionResult GetEmployee()
        {
            return Ok(db.Employee.ToList()
                                 .ConvertAll(p => new ResponseEmployee(p)));
        }

        [Route("api/Login")]
        [ResponseType(typeof(ResponseEmployee))]
        public IHttpActionResult Login([FromBody] Data data)
        {
            var user = db.Employee.ToList()
                                  .Where(p => p.Username == data.username && p.Password == HashPassword.Hash(data.password, "половой огран"))
                                  .FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            else
            
            {
                return Ok(new ResponseEmployee(user));
            }
        }

        public class Data
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employee.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employee.Count(e => e.Id == id) > 0;
        }
    }
}