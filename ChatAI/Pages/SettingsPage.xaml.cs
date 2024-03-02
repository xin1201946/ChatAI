using ChatAI.cs;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Configuration;

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
            API_URL_TEXTBOX.Text = settingschatai.apiurl;
            model_selected.SelectedItem = settingschatai.model;
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            VersionText.Text = "Version:" + version;
            MAXTOKEN_TEXTBOX.Text = settingschatai.MaxToken.ToString();
            GUIDTEXT.Text = "GUID: " + settingschatai.GUID;
        }
        private void savebutton_Click(object sender, RoutedEventArgs e)
        {
            if (model_selected.SelectedItem is string selectedModel)
            {
                // 使用选定的值
                settingschatai.model = selectedModel;
            }
            settingschatai.apikey = API_KEY_TEXTBOX.Text;
            settingschatai.apiurl = API_URL_TEXTBOX.Text;
            settingschatai.MaxToken = int.Parse(MAXTOKEN_TEXTBOX.Text);
            settingschatai.SetSetting("apikey", API_KEY_TEXTBOX.Text);
            settingschatai.SetSetting("apiurl", API_URL_TEXTBOX.Text);
            settingschatai.SetSetting("model", settingschatai.model);
            settingschatai.SetSetting("MaxToken", MAXTOKEN_TEXTBOX.Text);
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
            ToggleThemeTeachingTip1.Subtitle = "key:" + settingschatai.apikey + "\nUrl:" + settingschatai.apiurl + "\nModel:" + settingschatai.model;
            ToggleThemeTeachingTip1.IsOpen = true;

        }
    }
}
