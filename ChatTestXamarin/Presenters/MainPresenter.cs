using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatTestXamarin.Activities;
using ChatTestXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatTestXamarin.Presenters
{
    public class MainPresenter
    {
        private MainActivity _activity;
        private MainModel _model;

        public MainPresenter(MainActivity activity, MainModel model) 
        {
            _activity = activity;
            _model = model;
        }

        public List<Chat> GetChats()
        {
            return _model.Chats;
        }

        public void ChatClick(Chat chat)
        {
            var intent = new Intent(_activity, typeof(ChatActivity));
            var chatJson = JsonConvert.SerializeObject(chat);
            intent.PutExtra(nameof(Chat), chatJson);
            _activity.StartActivity(intent);
        }

        public void AddChat(string title)
        {
            var chat = new Chat(title);
            chat.Messages.Add(new ChatMessage(MainModel.Robot, "Привет!"));
            _model.Chats.Add(chat);
        }

        public void OpenAddChatDialog()
        {
            var dialog = new AddChatDialog(_activity);
            dialog.ChatAdd += (sender, title) => AddChat(title);
            dialog.Show();
        }
    }
}