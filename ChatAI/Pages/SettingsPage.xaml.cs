using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using ChatAI.cs;
using System.Diagnostics;
using Windows.ApplicationModel.Chat;
using CommunityToolkit.WinUI.Helpers;
using System.Runtime.ConstrainedExecution;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ChatAI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
 
            List<string> models = settingschatai.models;

            // 绑定数据源到ComboBox
            model_selected.ItemsSource = models;

            // 可选：设置默认选项
            model_selected.SelectedIndex = 0;

            API_KEY_TEXTBOX.Text = settingschatai.apikey;
            API_URL_TEXTBOX.Text=settingschatai.apiurl;
            model_selected.SelectedItem = settingschatai.model;
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string ver = string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision.ToString("0000"));
            VersionText.Text = "Version:" + ver;
            GUIDTEXT.Text = "GUID: "+settingschatai.GUID;
        }
        private void savebutton_Click(object sender, RoutedEventArgs e)
        {
            if (model_selected.SelectedItem is string selectedModel)
            {
                // 使用选定的值
                settingschatai.model = selectedModel;
            }
            settingschatai.apikey = API_KEY_TEXTBOX.Text;
            settingschatai.apiurl= API_URL_TEXTBOX.Text;

            settingschatai.SetSetting("apikey", API_KEY_TEXTBOX.Text);
            settingschatai.SetSetting("apiurl", API_URL_TEXTBOX.Text);
            settingschatai.SetSetting("model", settingschatai.model);
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.helpPage));
            
        }
        private void OpenWebView(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.WebView));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToggleThemeTeachingTip1.Subtitle = "key:"+settingschatai.apikey+"\nUrl:"+settingschatai.apiurl+"\nModel:"+settingschatai.model;
            ToggleThemeTeachingTip1.IsOpen = true;

        }
    }
}
