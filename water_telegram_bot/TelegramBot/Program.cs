using System;
using System.Collections.Generic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
	class Program
	{
		private static TelegramBotManager botManager = new TelegramBotManager();

		public static void Main(string[] args)
		{
			botManager.initAllBotSettings();
			Console.WriteLine("Chat started success");
			while (true) {
				Thread.Sleep(100);
			}
			botManager.stopTelegrammBot();
			Console.WriteLine("Stopped some errors");
		}
	}
}
