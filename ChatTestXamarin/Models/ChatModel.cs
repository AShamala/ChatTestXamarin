using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatTestXamarin.Models
{
    public class ChatModel
    {
        public Chat Chat { get; set; }

        public ChatModel(Chat chat)
        {
            Chat = chat;
        }

        public void CreateMessage(string message, User user)
        {
            Chat.Messages.Add(new ChatMessage(user, message));
        }
    }
}