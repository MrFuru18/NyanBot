

namespace NyanBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Everynyan!!! UwU");

            var nyanBot = new NyanBot();
            nyanBot.MainAsync().GetAwaiter().GetResult();
        }

    }
}