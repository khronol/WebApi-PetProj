using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.IO;
using System.Threading;
using System.Data.SqlClient;

namespace SkillProfi_tgBot
{
    public class Connect
    {
        static TelegramBotClient bot;
        static string token = System.IO.File.ReadAllText(@"token.txt");
        static string name = string.Empty;
        static string eMail = string.Empty;
        static string appeal = string.Empty;
        static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Appeals;Trusted_Connection=True;";
        public void ConnectBot()
        {
            bot = new TelegramBotClient(token);
            bot.StartReceiving(Update,Error);
        }

        private async static Task Update(ITelegramBotClient client, Telegram.Bot.Types.Update update, CancellationToken token)
        {
            var message = update.Message;
            if(message.Text != null)
            {
                if(message.Text.ToLower().Contains("/start"))
                {
                   await client.SendTextMessageAsync(message.Chat.Id, "Вы попали в телеграм-бот нашей It-Consulitng" +
                       " агенства #SkillProfi, здесь вы можете оставить свою заявку!");
                    await client.SendTextMessageAsync(message.Chat.Id, "Для составления заявки напишите мне:");
                    await client.SendTextMessageAsync(message.Chat.Id, "/new");
                    return;
                }
                if (message.Text.ToLower().Contains("/new"))
                {
                    
                    if (eMail == null) eMail = "Anonymous";
                    await client.SendTextMessageAsync(message.Chat.Id, "Вы можете оставить мне свою заявку и я ее обязательно передам!" +
                        " Напишите сейчас ваше обращение!");
                    
                    return;
                }
                if(message.Text != null)
                {
                    name = message.Chat.FirstName;
                    eMail = message.Chat.Username;
                    appeal = message.Text.ToLower();

                    await Console.Out.WriteLineAsync(name);
                    await Console.Out.WriteLineAsync(eMail);
                    await Console.Out.WriteLineAsync(appeal);
                    await client.SendTextMessageAsync(message.Chat.Id, $"Регистрирую ваше обращение как: \"{appeal}\"");
                    await client.SendTextMessageAsync(message.Chat.Id, "Если вы хотите зарегестрировать еще одно обращение напишите мне:/new");
                    ToSql(name,eMail,appeal);
                    using (StreamWriter sw = new StreamWriter("botLogs.txt",true,Encoding.UTF8))
                    {
                        sw.WriteLine("Имя пользователя: {0}",name);
                        sw.WriteLine("UserName: {0}", eMail);
                        sw.WriteLine("Обращение: {0}", appeal);

                    }
                }
            }
        }
        private Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        static void ToSql(string name, string email, string appeal)
        {
            string sqlExpression = $"INSERT INTO Appeals (Name,Email,userAppeal) VALUES (N'{name}',N'tgUsername:{email}',N'{appeal}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
