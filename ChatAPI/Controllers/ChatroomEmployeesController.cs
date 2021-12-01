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
using ChatAPI.Model;
using ChatAPI.Models;

namespace ChatAPI.Controllers
{
    public class ChatroomEmployeesController : ApiController
    {
        private ChatBDEntities db = new ChatBDEntities();

        // GET: api/ChatroomEmployees
        [ResponseType(typeof(List<ResponseChatroomEmployee>))]
        public IHttpActionResult GetChatroomEmployee()
        {
            return Ok(db.ChatroomEmployee.ToList().ConvertAll(p => new ResponseChatroomEmployee(p)));
        }

        // GET: api/ChatroomEmployees/5
        [ResponseType(typeof(ChatroomEmployee))]
        public IHttpActionResult GetChatroomEmployee(int id)
        {
            ChatroomEmployee chatroomEmployee = db.ChatroomEmployee.Find(id);
            if (chatroomEmployee == null)
            {
                return NotFound();
            }

            return Ok(chatroomEmployee);
        }

        // PUT: api/ChatroomEmployees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChatroomEmployee(int id, ChatroomEmployee chatroomEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatroomEmployee.Id)
            {
                return BadRequest();
            }

            db.Entry(chatroomEmployee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatroomEmployeeExists(id))
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

        // POST: api/ChatroomEmployees
        [ResponseType(typeof(ChatroomEmployee))]
        public IHttpActionResult PostChatroomEmployee(ChatroomEmployee chatroomEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChatroomEmployee.Add(chatroomEmployee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chatroomEmployee.Id }, chatroomEmployee);
        }

        // DELETE: api/ChatroomEmployees/5
        [ResponseType(typeof(ChatroomEmployee))]
        public IHttpActionResult DeleteChatroomEmployee(int id)
        {
            ChatroomEmployee chatroomEmployee = db.ChatroomEmployee.Find(id);
            if (chatroomEmployee == null)
            {
                return NotFound();
            }

            db.ChatroomEmployee.Remove(chatroomEmployee);
            db.SaveChanges();

            return Ok(chatroomEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatroomEmployeeExists(int id)
        {
            return db.ChatroomEmployee.Count(e => e.Id == id) > 0;
        }
    }
}