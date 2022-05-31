using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatTestXamarin.Adapters
{
    public class MessagesItemDecoration : RecyclerView.ItemDecoration
    {
        public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
        {
            var position = parent.GetChildAdapterPosition(view);
            if (position == RecyclerView.NoPosition) return;
            outRect.Left = 16;
            outRect.Bottom = 8;
            outRect.Right = 16;
            if (position == 0)
                outRect.Top = 8;
        }
    }
}