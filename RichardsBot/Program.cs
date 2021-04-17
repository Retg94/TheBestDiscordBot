using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace RichardsBot
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = "ODMyMjI2NzkxODU5MDI3OTY4.YHgtmQ.mP4U08CW3tpoF5EAOh58p32zlQw",
                TokenType = TokenType.Bot
            });

            discordClient.MessageCreated += OnMessageCreated;
            await discordClient.ConnectAsync();
            await Task.Delay(-1);

        }

        private static bool containWordOrNot(string word, string sentence)
        {
            bool result = false;
            if (sentence.Contains(word, StringComparison.OrdinalIgnoreCase))
                result = true;
            return result;
        }

        private static async Task OnMessageCreated(MessageCreateEventArgs e)
        {
            Console.WriteLine(e);
            if (string.Equals(e.Message.Content, "There's vomit on his sweater already, mom's spaghetti", StringComparison.OrdinalIgnoreCase))
            {
                await e.Message.RespondAsync("He's nervous, but on the surface he looks calm and ready");
            } 
            else if(string.Equals(e.Message.Content, "The clocks run out, times up, over, blaow", StringComparison.OrdinalIgnoreCase))
            {
                await e.Message.RespondAsync("Snap back to reality, ope there goes gravity");
            }
            else if (string.Equals(e.Message.Content, "potatis 25", StringComparison.OrdinalIgnoreCase))
            {
                string potato = "POTATO";
                for(int i=0; i<25; i++)
                {
                    await e.Message.RespondAsync(potato);
                    potato += "O";
                }
            }
            else if (containWordOrNot("potatis", e.Message.Content))
            {
                await e.Message.RespondAsync("POTATO POTATITOS POTATO");
            }
            else if (string.Equals(e.Message.Content, "heart", StringComparison.OrdinalIgnoreCase))
            {
                Image Picture = Image.FromFile(@"C:\Users\retg9\Pictures\ProjectMolnBilder\heart.png");
                Console.SetBufferSize((Picture.Width * 0x2), (Picture.Height * 0x2));
                FrameDimension Dimension = new FrameDimension(Picture.FrameDimensionsList[0x0]);
                int FrameCount = Picture.GetFrameCount(Dimension);
                int Left = Console.WindowLeft, Top = Console.WindowTop;
                char[] Chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
                Picture.SelectActiveFrame(Dimension, 0x0);
                for (int i = 0x0; i < Picture.Height; i++)
                {
                    for (int x = 0x0; x < Picture.Width; x++)
                    {
                        Color Color = ((Bitmap)Picture).GetPixel(x, i);
                        int Gray = (Color.R + Color.G + Color.B) / 0x3;
                        int Index = (Gray * (Chars.Length - 0x1)) / 0xFF;
                        await e.Message.RespondAsync(Chars[Index].ToString());
                    }
                    Console.Write('\n');
                }
            }


        }

    }
}