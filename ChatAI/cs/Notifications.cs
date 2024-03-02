namespace ChatAI.cs
{
    internal class Notifications
    {
        static public void showinfo(string title, string message)
        {
            var a = new CommunityToolkit.WinUI.Notifications.ToastContentBuilder();
            a.AddText(title);
            a.AddText(message);
            a.Show();
        }
    }

}
