using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;

public static class Editor
{
    public static void Show()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("MODO EDITOR");
        Console.WriteLine("---------------");
        Start();
    }

    public static void Start()
    {
        var file = new StringBuilder();

        do
        {
            file.Append(Console.ReadLine());
            file.Append(Environment.NewLine);
        } while (Console.ReadKey().Key != ConsoleKey.Escape);

        Console.WriteLine("---------------");
        MenuSave(file);
    }

    public static void MenuSave(object file)
    {
        Console.WriteLine("DDeseja Salvar o arquivo?");
        Console.WriteLine("");
        Console.WriteLine("1 - Sim");
        Console.WriteLine("2 - Não");
        Console.Write("Opção: ");

        short option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1: Save(file); break;
            case 2:
                {

                    Console.ReadKey();
                    Environment.Exit(0);
                }; break;

            default: MenuSave(file); break;
        }
    }

    public static void Save(object text)
    {
        Console.WriteLine("Insira o caminho para salvar o arquivo");

        // string path = @"C:\DEV Projetos\C#\EditorHtml\ arquivo.txt";
        string path = Console.ReadLine();

        using (var file = new StreamWriter(path))
        {
            Console.Clear();
            file.Write(text);
        }

        Console.WriteLine($"Arquivo salvo com sucesso no caminho {path}");
        Console.ReadKey();
        Menu.Show();
    }


}