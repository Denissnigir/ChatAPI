using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.Model
{
    public partial class Chatroom
    {
        public string GetLastMessage
        {
            get
            {
                string message = "Нет";
                try
                {
                    message = ChatMessage?.Where(p => p.ChatroomId == Id)?
                                          .ToList()?
                                          .LastOrDefault()?.Message ?? "Нет сообщений";

                    return message;
                }
                catch
                {
                    return message;
                }
                
            }
        }
    }
}