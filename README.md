# MakerShowBotTestClient
Sample UWP project in C# for Windows 10 to test Direct Line calls to The Maker Show bot. This client project can be used to communicate with any bot created with the [Microsoft Bot Framework](https://dev.botframework.com).

## Related Projects
- [The Maker Show Bot](https://github.com/ActiveNick/TheMakerShowBot): This bot helps you get started as a maker by recommending online resources about project ideas, where to buy hardware boards, sensors and other parts, and more. This bot also recommends specific episodes of [The Maker Show](http://themakershow.io) to watch based on your interests.
- [HoloBot](https://github.com/ActiveNick/HoloBot): A sample Unity project for Microsoft HoloLens that lets you interact with a holographic speech-enabled bot character, powered by the Microsoft Bot Framework and LUIS from Microsoft Cognitive Services. This UWP test client project served as a test bed for the Bot Framework code integrated into HoloBot.

## Connecting your Bot to the UWP Test Client
- Create and register your bot as per the intructions at https://dev.botframework.com. Since users can type with natural language queries, it is highly recommended that your bot support NLP via [Natural Language Understanding Service](https://www.microsoft.com/cognitive-services/en-us/language-understanding-intelligent-service-luis) (LUIS) from [Microsoft Cognitive Services](https://www.microsoft.com/cognitive-services)
- Enable the Direct Line channel on your bot
- Generate and copy your Direct Line secret (aka API key)
- Open **BotService.cs** and paste your Direct Line secret in the **_APIKEY** private string

## Follow Me
- Twitter: [@ActiveNick](http://twitter.com/ActiveNick)
- Blog: [AgeofMobility.com](http://AgeofMobility.com)
