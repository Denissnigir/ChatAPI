using ChatAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.Models
{
    public partial class ResponseChatroomEmployee
    {
        public ResponseChatroomEmployee(ChatroomEmployee chatroomEmployee)
        {
            id = chatroomEmployee.Id;
            chatroomId = chatroomEmployee.ChatroomId;
            employeeId = chatroomEmployee.EmployeeId;
            getName = chatroomEmployee.getName;
        }

        public int id { get; set; }
        public int chatroomId { get; set; }
        public int employeeId { get; set; }
        public string getName { get; set; }
    }
}