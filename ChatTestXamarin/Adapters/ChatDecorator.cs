using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatTestXamarin.Adapters
{
    public static class ChatDecoration
    {
        public static string GetCharsForIcon(string title)
        {
            var words = title.Trim().Split(" ");
            if (words.Length > 1)
                return $"{words[0][0]}{words[^1][0]}".ToUpper();
            else
                return $"{words[0][0]}".ToUpper();
        }

        public static Color GetColorForIcon(char c)
        {
            var colors = new List<string>()
            {
                "#d16060",
                "#529be3",
                "#4ac257",
                "#e6ae55"
            };

            var color = string.Empty;
            var colorsCount = colors.Count;
            for (int i = 0; i < colorsCount; i++)
            {
                if ((c + i) % colorsCount == 0)
                {
                    color = colors[i];
                    break;
                }
            }
            return Color.ParseColor(color);
        }

        public static string DecorateName(string name)
        {
            return name + ": ";
        }
    }

    public static class DateTimeExtensions
    {
        public static string ToStringForChat(this DateTime dateTime)
        {
            var timeNow = DateTime.Now;
            string result;
            if (timeNow.Year > dateTime.Year)
                result = dateTime.ToString("d");
            else if ((timeNow.DayOfYear > dateTime.DayOfYear))
                result = dateTime.ToString("MMM dd");
            else
                result = dateTime.ToString("t");
            return result;
        }
    }
}