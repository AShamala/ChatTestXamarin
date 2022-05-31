using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ChatTestXamarin.Models;
using System;
using System.Collections.Generic;

namespace ChatTestXamarin.Adapters
{
    internal class MessageAdapter : RecyclerView.Adapter
    {
        private List<ChatMessage> _messages;

        public MessageAdapter(List<ChatMessage> messages)
        {
            _messages = messages;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.message_list_item, parent, false);
            var vh = new MessageAdapterViewHolder(itemView);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var message = _messages[position];
            var holder = viewHolder as MessageAdapterViewHolder;
            var paramsLayout = holder.Layout.LayoutParameters as RelativeLayout.LayoutParams;
            paramsLayout.RemoveRule(LayoutRules.AlignParentRight);
            if (message.Sender.Name == "Пользователь")
                (holder.Layout.LayoutParameters as RelativeLayout.LayoutParams)
                    .AddRule(LayoutRules.AlignParentRight);

            holder.Message.Text = message.Text;
            holder.Date.Text = message.Date.ToStringForChat();
            holder.Name.Text = message.Sender.Name;
        }

        public override int ItemCount => _messages.Count;
    }

    public class MessageAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView Message { get; set; }
        public TextView Name { get; set; }
        public TextView Date { get; set; }
        public LinearLayout Layout { get; set; }

        public MessageAdapterViewHolder(View itemView) : base(itemView)
        {
            Message = itemView.FindViewById<TextView>(Resource.Id.messageTextView);
            Name = itemView.FindViewById<TextView>(Resource.Id.messageNameTextView);
            Date = itemView.FindViewById<TextView>(Resource.Id.messageDateTextView);
            Layout = itemView.FindViewById<LinearLayout>(Resource.Id.linearLayout1);
        }
    }
}