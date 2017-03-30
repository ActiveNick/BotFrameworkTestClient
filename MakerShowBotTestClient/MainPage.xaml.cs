using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MakerShowBotTestClient
{
    /// <summary>
    /// This sample app to test Direct Line calls to communicate with any bot created 
    /// with the Microsoft Bot Framework.
    /// Note that this code currently only supports the Direct Line 1.1 API.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BotService tmsBot;
        string ConversationId;

        public MainPage()
        {
            this.InitializeComponent();

            // This is the Direct Line secret to communicate with Nick Landry's Maker Show Bot.
            // Replace this with your own secret or paste it in the textbox at runtime.
            txtSecret.Text = "PN3lBLvTXwU.cwA.Kb8.qA6OkFZcgx2hLRSAlteqKnCZqYcQD_orUi_kwyw6i8k";

            tmsBot = new BotService();            
        }

        private async void btnAsk_Click(object sender, RoutedEventArgs e)
        {

            string msg = txtInput.Text;

            if (await tmsBot.SendMessage(msg))
            {
                ConversationMessages messages = await tmsBot.GetMessages();
                for (int i = 1; i < messages.messages.Length; i++)
                {
                    lblMessage.Text += messages.messages[i].text + Environment.NewLine;
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblMessage.Text = "";
        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ConversationId = await tmsBot.StartConversation(txtSecret.Text);
            btnStart.IsEnabled = false;
            btnAsk.IsEnabled = true;
        }
    }
}
