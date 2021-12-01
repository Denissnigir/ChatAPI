using ChatAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.Models
{
    public partial class ResponseChatMessage
    {
        public ResponseChatMessage(ChatMessage chatMessage)
        {
            id = chatMessage.Id;
            senderId = chatMessage.SenderId;
            chatroomId = chatMessage.ChatroomId;
            date = chatMessage.Date;
            message = chatMessage.Message;
            getMessage = chatMessage.GetMessage;
        }

        public int id { get; set; }
        public int senderId { get; set; }
        public int chatroomId { get; set; }
        public DateTime date { get; set; }
        public string message { get; set; }

        public string getMessage { get; set; }
    }
}