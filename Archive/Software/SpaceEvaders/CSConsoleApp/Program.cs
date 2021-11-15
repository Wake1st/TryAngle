using System;

namespace CSConsoleApp
{
    class Program
    {
        static string[] ship = {
            "  ^  ",
            " /o\\ ",
            " \\_/ "
        };

        static void Main(string[] args)
        {
            //  Create game object
            GameEngine engine = new GameEngine();

            engine.VisualElements.Add(new VisualElement(200, 50, 0, 0, 0));
            engine.LoadVisualElement(ship, 100, 20, 1);

            //  Begin game
            engine.Run();
        }
    }
}
