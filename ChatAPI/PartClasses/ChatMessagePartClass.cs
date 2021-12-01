using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.Model
{
    public partial class ChatMessage
    {
        private ChatBDEntities db = new ChatBDEntities();

        public string GetMessage
        {
            get
            {
                var emp = db.Employee.Where(p => p.Id == SenderId).FirstOrDefault();
                string message = $"[{Date.Hour}:{Date.Minute}] {emp.FirstName} {emp.SecondName}: {Message}";
                return message;
            }
        }
    }
}