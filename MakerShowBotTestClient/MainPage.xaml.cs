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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MakerShowBotTestClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BotService tmsBot;
        string ConversationId;

        public MainPage()
        {
            this.InitializeComponent();

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
            ConversationId = await tmsBot.StartConversation();
            btnStart.IsEnabled = false;
            btnAsk.IsEnabled = true;
        }
    }
}
