using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.Model
{
    public partial class ChatroomEmployee
    {
        private ChatBDEntities db = new ChatBDEntities();

        public string getName
        {
            get
            {
                var emp = db.Employee.Where(p => p.Id == EmployeeId).FirstOrDefault();
                string name = $"{emp.FirstName} {emp.SecondName}";
                return name;
            }
        }
    }
}