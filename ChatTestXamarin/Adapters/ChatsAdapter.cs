using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using ChatTestXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Graphics.PorterDuff;

namespace ChatTestXamarin.Adapters
{
    public class ChatsAdapter : RecyclerView.Adapter
    {
        private List<Chat> _chats;
        public event EventHandler<Chat> ChatClick;

        public ChatsAdapter(List<Chat> chats)
        {
            _chats = chats;
        }

        private void OnClick(Chat chat)
        {
            if (ChatClick != null)
                ChatClick(this, chat);
        }

        public override int ItemCount => _chats.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as ChatHolder;

            var title = _chats[position].Title;
            var iconChars = ChatDecoration.GetCharsForIcon(title);
            var lastMessage = _chats[position].GetLastMessage();

            vh.Title.Text = title;
            vh.Icon.Text = iconChars;
            vh.Icon.Background.SetColorFilter(
                new BlendModeColorFilter(ChatDecoration.GetColorForIcon(iconChars[0]), BlendMode.Plus));
            if (lastMessage != null)
            {
                vh.Name.Text = ChatDecoration.DecorateName(lastMessage.Sender.Name);
                vh.Date.Text = lastMessage.Date.ToStringForChat();
                vh.Message.Text = lastMessage.Text;
            }
            vh.Chat = _chats[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.chat_list_item, parent, false);
            var viewHolder = new ChatHolder(itemView, OnClick);
            return viewHolder;
        }

        private class ChatHolder : RecyclerView.ViewHolder
        {
            public TextView Title { get; private set; }
            public TextView Name { get; private set; }
            public TextView Date { get; private set; }
            public TextView Message { get; private set; }
            public TextView Icon { get; private set; }

            public Chat Chat { get; set; }

            public ChatHolder(View itemView, Action<Chat> onClick) : base(itemView)
            {
                Title = itemView.FindViewById<TextView>(Resource.Id.chatTitleTextView);
                Name = itemView.FindViewById<TextView>(Resource.Id.chatLastMessageNameTextView);
                Date = itemView.FindViewById<TextView>(Resource.Id.chatLastMessageDateTextView);
                Message = itemView.FindViewById<TextView>(Resource.Id.chatLastMessageTextView);
                Icon = itemView.FindViewById<TextView>(Resource.Id.chatIconText);

                itemView.Click += (sender, e) => onClick(Chat);
            }
        }
    } 
}