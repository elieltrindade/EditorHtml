using System.Text.RegularExpressions;

public class Viewer
{

    public static void Show()
    {
        Console.Clear();

        Console.Write("Insira o caminho do arquivo: ");

        // string path = @"C:\DEV Projetos\C#\EditorHtml\ arquivo.txt";
        string path = Console.ReadLine();

        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("MODO VIZUALIZAÇÃO");
        Console.WriteLine("---------------");

        using (var file = new StreamReader(path))
        {
            string text = file.ReadToEnd();

            Replace(text);
        }
        Console.WriteLine("");
        Console.ReadKey();
        Menu.Show();

    }
    public static void Replace(string text)
    {
        var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
        var words = text.Split(' ');

        for (var i = 0; i < words.Length; i++)
        {
            if (strong.IsMatch(words[i]))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(
                    words[i].Substring(
                        words[i].IndexOf('>') + 1,
                        (
                        (words[i].LastIndexOf('<') - 1) -
                        words[i].IndexOf('>')
                        )
                    )
                );
                Console.Write(" ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(words[i]);
                Console.Write(" ");
            }
        }
    }

}
