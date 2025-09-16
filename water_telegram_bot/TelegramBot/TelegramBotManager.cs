using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Web;

namespace TelegramBot
{
    public class TelegramBotManager
    {
        private static TelegramBotClient client;
		private static DatabaseManager databaseManager = new DatabaseManager();
        public String GetBotKey() {
            string bot_key = String.Empty;
            try {
                bot_key = ConfigurationManager.AppSettings["bot_key"];
            }
            catch (Exception e) {
                bot_key = String.Empty;
            }
            return bot_key;
        }
		private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
		{
			var message = messageEventArgs.Message;

			Console.WriteLine("CHAT_ID:"+ message.Chat.Id);
			
			KeyboardButton button = KeyboardButton.WithRequestContact("Регистрация");
			var rkm = new ReplyKeyboardMarkup();
			rkm.ResizeKeyboard = true;
			rkm.Keyboard =
				new KeyboardButton[][]
				{
				new KeyboardButton[]
				{
					button,
					new KeyboardButton("Услуги")
				},

				new KeyboardButton[]
				{
					new KeyboardButton("Информация")
				}
			};
			

			//MESSAGE CHECKER 
			if (message?.Type == MessageType.Text)
			{
				String messageStr = "Unknown command";
				if (message.Text.Equals("Информация"))
				{
					messageStr = databaseManager.getInformation();
				}
				else if (message.Text.Equals("Услуги"))
				{
					messageStr = databaseManager.getServiceTypeList();
				}
				else {
					int n;
					bool isNumeric = int.TryParse(message.Text.Trim(), out n);
					if (isNumeric)
					{
						//@extresoft
						//String channel_name_as_id = "-1001662143739";
						//String message_str_mss = "SMS BOT";
						//await client.SendTextMessageAsync(long.Parse(channel_name_as_id), message_str_mss, replyMarkup: rkm);


						WaterAddress address = databaseManager.getAddressFullInfo(n);
						String title = address.tuman_nomi + " || " + address.client_name;
						String info = address.address;
						try {
                            await client.SendVenueAsync(
                            chatId: message.Chat.Id,
                            latitude: float.Parse(address.lat.ToString()),
                            longitude: float.Parse(address.lan.ToString()),
                            title: title,
                            address: info,
                            replyMarkup: rkm);
                        }
						catch (Exception) { 
						
						}
					
						return;
					}
					else {
						String message_str = message.Text.Trim();
						List<WaterClient> waterClients = databaseManager.getClientListInfoIds(message_str);
						foreach (WaterClient itm in waterClients) {

							String title = itm.tuman + "  " + itm.fio;
							String message_str_ms = itm.address + "  " + itm.note + "  " + " (Bakalashka:) "+itm.bakalashka;

							try
							{
                                await client.SendVenueAsync(
								chatId: message.Chat.Id,
								latitude: float.Parse(itm.lati.ToString()),
								longitude: float.Parse(itm.longi.ToString()),
								title: title,
								address: itm.fio,
								replyMarkup: rkm);
                            }
							catch (Exception) {
								return;
							}
							

							if (message_str_ms.Trim().Length > 0) {
								await client.SendTextMessageAsync(message.Chat.Id, message_str_ms, replyMarkup: rkm);

							}
							await client.SendTextMessageAsync(message.Chat.Id, itm.phone_number, replyMarkup: rkm);



						}

						if (waterClients.Count > 0) {
							return;
						}


					}
				}
				string[] arrayStr = messageStr.Split("\\n");
				if (arrayStr != null && arrayStr.Length > 0)
				{
					foreach (string msg in arrayStr) {
						if (msg.Trim().Length > 0) {
							try
							{
                                await client.SendTextMessageAsync(message.Chat.Id, msg, replyMarkup: rkm);
                            }
							catch(Exception) {
								return;
							}
							
						}
					}	
				}
				else {
					await client.SendTextMessageAsync(message.Chat.Id, messageStr, replyMarkup: rkm);
				}

				
			}
			//CONTACT CHECKER
			if (message?.Type == MessageType.Contact) {
				String phoneNumberStr = message.Contact.PhoneNumber;
				if (!phoneNumberStr.Contains("+")) {
					phoneNumberStr = "+"+phoneNumberStr;
				}
				
				Console.WriteLine(phoneNumberStr);

				//CONTACT
				String messageContactStr = databaseManager.registratsiyaContragent(phoneNumberStr, message.Chat.Id);
				await client.SendTextMessageAsync(message.Chat.Id, messageContactStr,  replyMarkup: rkm);
			}
		}
		
		public bool initAllBotSettings() {
			try
			{
				
				client = new TelegramBotClient(GetBotKey());
				client.OnMessage += BotOnMessageReceived;
				client.OnMessageEdited += BotOnMessageReceived;
				client.StartReceiving();

				return true;
			}
			catch(Exception e) {
				return false;
			}

		}
		public void stopTelegrammBot() {
			client.StopReceiving();

		}


	}
}
