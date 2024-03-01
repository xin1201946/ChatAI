using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit;

namespace ChatAI.cs
{
    internal class Notifications
    {
         static public void showinfo(string title,string message)
        {
            var a = new CommunityToolkit.WinUI.Notifications.ToastContentBuilder();
            a.AddText(title);
            a.AddText(message);
            a.Show();
        }
    }

}
