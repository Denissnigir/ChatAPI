using ChatAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.Models
{
    public partial class ResponseChatRoom
    {
        public ResponseChatRoom(Chatroom chatroom)
        {
            id = chatroom.Id;
            topic = chatroom.Topic;
            lastMessage = chatroom.GetLastMessage;
        }
        public int id { get; set; }
        public string topic { get; set; }
        public string lastMessage { get; set; } = null;
    }
}