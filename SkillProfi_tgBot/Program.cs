using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillProfi_tgBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Connect bot = new Connect();
            bot.ConnectBot();
            Console.ReadKey();
        }
    }
}
