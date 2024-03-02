using ChatAI.cs;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using OpenAI;
using CommunityToolkit.WinUI;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using System.Collections.Generic;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ChatAI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChatAI : Page
    {
        private OpenAIService openAiService;
        private List<ChatMessage> conversationHistory = new List<ChatMessage> {
            ChatMessage.FromUser("����һ���ܰ����˹�����"),
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
                    ToggleThemeTeachingTip1.Subtitle = "������,���openaiKey������Ҫ��:\n" + openAiKey;
                    ToggleThemeTeachingTip1.IsOpen = true;
                    return;
                }
                InputTextBox.Text = string.Empty;
                AddMessageToConversation($"User: {userInput}");
                conversationHistory.Add(ChatMessage.FromUser(userInput));
                var completionResult = await openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest()
                {
                    Messages = conversationHistory,
                    Model = modelname,
                    MaxTokens = Maxtoken
                });

                if (completionResult != null && completionResult.Successful)
                {
                    // չʾAI�ظ�����ӵ��Ի���ʷ
                    var aiResponse = completionResult.Choices.First().Message.Content;
                    AddMessageToConversation($"{modelname}: {aiResponse}");
                    conversationHistory.Add(ChatMessage.FromAssistant(aiResponse));
                }
                else
                {
                    ToggleThemeTeachingTip1.Subtitle = "������:\n" + completionResult.Error?.Message;
                    ToggleThemeTeachingTip1.IsOpen = true;
                }
            }
        }

        private void AddMessageToConversation(string message)
        {
            ChatBox.Text += "\n\n" + message;
        }
    }
}
