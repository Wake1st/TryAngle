using System;
using System.Collections.Generic;

namespace CSConsoleApp
{
    class Program
    {
        static string[] ship = {
            "/^^^\\",
            "|-o-|",
            "\\___/"
        };

        static void Main(string[] args)
        {
            //  Create game object
            GameEngine engine = new GameEngine();

            engine.VisualElements.Add(new VisualElement(200, 50, 0, 0, 0));
            engine.LoadVisualElement("ship", ship, 100, 20, 1);
            engine.LoadVisualElement("stars", CreateStars(engine), 0, 0, byte.MaxValue - 10);

            //  Begin game
            engine.Run();
        }

        static string[] CreateStars(GameEngine engine)
        {
            List<string> stars = new List<string>();
            var rand = new Random();

            for (int j = 0; j < engine.BoardHeight; j++)
            {
                stars.Add("");

                for (int i = 0; i < engine.BoardWidth; i++)
                {
                    stars[j] += (rand.Next(36) == 0) 
                        ? (rand.Next(7) == 0 ? "*" : ".")
                        : " "; 
                }
            }

            return stars.ToArray();
        }
    }
}
