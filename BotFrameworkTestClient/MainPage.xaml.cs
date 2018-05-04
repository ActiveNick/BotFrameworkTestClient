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
using Windows.Media.SpeechSynthesis;
using BotFrameworkTestClient.Models;

namespace BotFrameworkTestClient
{
    /// <summary>
    /// This sample app to test Direct Line calls to communicate with any bot created 
    /// with the Microsoft Bot Framework v3 or v4. Support for v4 bots is still in testing.
    /// This code now only support the Direct Line 3.0 API.
    /// DirectLine 1.1 is no longer being tested and may not work anymore. Consider 1.1 support to be deprecated.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BotService myBot;
        string ConversationId;

        public MainPage()
        {
            this.InitializeComponent();

            // This is the Direct Line secret to communicate with Nick Landry's Maker Show Bot.
            // Replace this with your own secret or paste it in the textbox at runtime.
            //txtSecret.Text = "PN3lBLvTXwU.cwA.Kb8.qA6OkFZcgx2hLRSAlteqKnCZqYcQD_orUi_kwyw6i8k";  //The Maker Show Bot
            txtSecret.Text = "ijt0FKWuWsI.cwA.pRE.HCw51c3WiT480Ixfg0rXsawt2CLAbfOFxGUzDJh2A0I"; // Nick Echo Bot
            //txtSecret.Text = "JyC-jIxlb_g.cwA.UDQ.26z8y5QZFL-aSOXCXYTsEVMMxaq_OQkEW0wLXNR9-Gk"; // Inquisitive Sample Bot

            myBot = new BotService();            
        }

        private async void btnAsk_Click(object sender, RoutedEventArgs e)
        {

            string msg = txtInput.Text;
            string spokenresult = "";

            if (await myBot.SendMessage(msg))
            {
                ConversationActitvities messages = await myBot.GetMessages();
                for (int i = 1; i < messages.activities.Length; i++)
                {
                    lblMessage.Text += messages.activities[i].Text + Environment.NewLine;
                    spokenresult += (messages.activities[i].Speak + " ");
                }
                ReadText(spokenresult);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblMessage.Text = "";
        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ConversationId = await myBot.StartConversation(txtSecret.Text);
            btnStart.IsEnabled = false;
            btnAsk.IsEnabled = true;
        }

        // Quickly adds Text-to-Speech to the app using Cortana's default voice
        private async void ReadText(string mytext)
        {
            //Reminder: You need to enable the Microphone capabilitiy in Windows Phone projects
            //Reminder: Add this namespace in your using statements
            //using Windows.Media.SpeechSynthesis;

            // The media object for controlling and playing audio.
            MediaElement mediaplayer = new MediaElement();

            // The object for controlling the speech synthesis engine (voice).
            using (var speech = new SpeechSynthesizer())
            {
                //Retrieve the first female voice
                speech.Voice = SpeechSynthesizer.AllVoices
                    .First(i => (i.Gender == VoiceGender.Female && i.Description.Contains("United States")));
                // Generate the audio stream from plain text.
                SpeechSynthesisStream stream = await speech.SynthesizeTextToStreamAsync(mytext);

                // Send the stream to the media object.
                mediaplayer.SetSource(stream, stream.ContentType);
                mediaplayer.Play();
            }
        }
    }
}
