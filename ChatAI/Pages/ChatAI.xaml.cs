using ChatAI.cs;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using OpenAI;
using CommunityToolkit.WinUI;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ChatAI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public class MessageItem
    {
        public string infotitle { get; set; }
        public string infoText { get; set; }
        public string Text { get; set; }
        public string title { get; set; }
        public SolidColorBrush Color { get; set; }
    }
    public sealed partial class ChatAI : Page
    {
        private OpenAIService openAiService;
        private List<ChatMessage> conversationHistory = new List<ChatMessage> {
            ChatMessage.FromSystem("你是一个很棒的人工助手"),
        };
        public ChatAI()
        {

            this.InitializeComponent();

        }
        
        
        private async void SendButton_Click(object sender, RoutedEventArgs e)

        {

            var openAiKey = settingschatai.apikey;
            var openAiUrl = settingschatai.apiurl;
            var modelname = settingschatai.model;
            var Maxtoken = settingschatai.MaxToken;
            string userInput = InputTextBox.Text;
            openAiService = new OpenAIService(new OpenAiOptions()
            {
                BaseDomain = openAiUrl,
                ApiKey = openAiKey,
            });


            if (!string.IsNullOrEmpty(userInput))
            {
                if (openAiKey == "sk-" || openAiKey == "")
                {
                    ToggleThemeTeachingTip1.Subtitle = "出错了,你的openaiKey不符合要求:\n" + openAiKey;
                    ToggleThemeTeachingTip1.IsOpen = true;
                    return;
                }
                InputTextBox.Text = string.Empty;
                AddMessageToConversation($"{userInput}", "User");
                conversationHistory.Add(ChatMessage.FromUser(userInput));
                var completionResult = await openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest()
                {
                    Messages = conversationHistory,
                    Model = modelname,
                    MaxTokens = Maxtoken
                });

                if (completionResult != null && completionResult.Successful)
                {
                    // 展示AI回复并添加到对话历史
                    var aiResponse = completionResult.Choices.First().Message.Content;
                    AddMessageToConversation($"{aiResponse}", $"{modelname}");
                    conversationHistory.Add(ChatMessage.FromAssistant(aiResponse));
                }
                else
                {
                    ToggleThemeTeachingTip1.Subtitle = "出错了:\n" + completionResult.Error?.Message;
                    ToggleThemeTeachingTip1.IsOpen = true;
                }
            }
        }

        private void AddMessageToConversation(string message,string title)
        {
            var messageItem = new MessageItem();
            messageItem.Text = message;
            ConversationList.Items.Add(messageItem);
            messageItem.title= title;
            // handle scrolling
            ConversationScrollViewer.UpdateLayout();
            ConversationScrollViewer.ChangeView(null, ConversationScrollViewer.ScrollableHeight, null);
        }
    }
}
