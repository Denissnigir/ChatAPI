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
    public class ChatMessagesController : ApiController
    {
        private ChatBDEntities db = new ChatBDEntities();

        // GET: api/ChatMessages
        [ResponseType(typeof(List<ResponseChatMessage>))]
        public IHttpActionResult GetChatMessage()
        {
            return Ok(db.ChatMessage.ToList()
                                    .ConvertAll(p => new ResponseChatMessage(p)));
        }

        // GET: api/ChatMessages/5
        [ResponseType(typeof(ChatMessage))]
        public IHttpActionResult GetChatMessage(int id)
        {
            ChatMessage chatMessage = db.ChatMessage.Find(id);
            if (chatMessage == null)
            {
                return NotFound();
            }

            return Ok(chatMessage);
        }

        // PUT: api/ChatMessages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChatMessage(int id, ChatMessage chatMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatMessage.Id)
            {
                return BadRequest();
            }

            db.Entry(chatMessage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatMessageExists(id))
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

        // POST: api/ChatMessages
        [ResponseType(typeof(ChatMessage))]
        public IHttpActionResult PostChatMessage([FromBody]ChatMessage chatMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChatMessage.Add(chatMessage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chatMessage.Id }, chatMessage);
        }

        // DELETE: api/ChatMessages/5
        [ResponseType(typeof(ChatMessage))]
        public IHttpActionResult DeleteChatMessage(int id)
        {
            ChatMessage chatMessage = db.ChatMessage.Find(id);
            if (chatMessage == null)
            {
                return NotFound();
            }

            db.ChatMessage.Remove(chatMessage);
            db.SaveChanges();

            return Ok(chatMessage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatMessageExists(int id)
        {
            return db.ChatMessage.Count(e => e.Id == id) > 0;
        }
    }
}