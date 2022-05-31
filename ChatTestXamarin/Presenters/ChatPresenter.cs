using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatTestXamarin.Activities;
using ChatTestXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatTestXamarin.Presenters
{
    public class ChatPresenter
    {
        private ChatActivity _activity;
        private ChatModel _model;
        public ChatPresenter(ChatModel model, ChatActivity activity)
        {
            _activity = activity;
            _model = model;
        }

        public void SendMessage(string message)
        {
            _model.CreateMessage(message, MainModel.User);
        }

        async public Task RobotAnswer()
        {
            await Task.Run(() =>
            {
                var random = new Random();
                var delay = random.Next(1000) + 1000;
                var answerVariant = random.Next(3);
                string message;
                if (answerVariant == 0)
                {
                    message = "Да!";
                }
                else if (answerVariant == 1)
                {
                    message = "Нет";
                }
                else
                {
                    message = "Отличная идея!";
                }
                Thread.Sleep(delay);
                _model.CreateMessage(message, MainModel.Robot);
            });
        }
    }
}