﻿using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.Windows.AppNotifications;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Diagnostics;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ChatAI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private AppWindow appWindow;
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.SizeChanged += SizeChanged;
            appWindow = GetAppWindow(m_window); //Set ExtendsContentIntoTitleBar for the AppWindow not the window
            appWindow.TitleBar.ExtendsContentIntoTitleBar = true;
            appWindow.TitleBar.ButtonBackgroundColor = Colors.Transparent;
            appWindow.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

            CommunityToolkit.WinUI.Notifications.ToastNotificationManagerCompat.OnActivated += ToastNotificationManagerCompat_OnActivated;
            m_window.Activate();
        }

        private static void ToastNotificationManagerCompat_OnActivated(CommunityToolkit.WinUI.Notifications.ToastNotificationActivatedEventArgsCompat e)
        {
            var ToastClickArgs = CommunityToolkit.WinUI.Notifications.ToastArguments.Parse(e.Argument);
            if (ToastClickArgs.Count > 0)
            {
                foreach (var ToastClickItem in ToastClickArgs)
                {
                    switch (ToastClickItem.Value)
                    {
                        case "aaa":
                            //执行代码块
                            Debug.WriteLine("成了！！！！！！！！！！");
                            break;
                    }
                }
            }
        }
            private void SizeChanged(object sender, WindowSizeChangedEventArgs args)
        {
            //Update the title bar draggable region. We need to indent from the left both for the nav back button and to avoid the system menu
            Windows.Graphics.RectInt32[] rects = new Windows.Graphics.RectInt32[] { new Windows.Graphics.RectInt32(48, 0, (int)args.Size.Width - 48, 48) };
            appWindow.TitleBar.SetDragRectangles(rects);
        }

        private AppWindow GetAppWindow(Window window)
        {
            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            return AppWindow.GetFromWindowId(windowId);
        }


        private Window m_window;
    }
}
