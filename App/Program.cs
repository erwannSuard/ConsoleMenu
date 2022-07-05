using static System.Console;
using System.Collections.Generic;
namespace ConsoleMenu;
class Program
{
    static void Main(string[] args)
    {
        // ConsoleKeyInfo key;
        // bool ok = false;
        // while(!ok)
        // {
        //     Write("Appuyez sur entrée pour clear la console : ");
        //     key = ReadKey();
        //     ok = key.Key switch
        //     {
        //         ConsoleKey.Enter => true,
        //         _ => false

        //     };
        //     if(key.Key == ConsoleKey.Enter)
        //     {
        //         ok = true;
        //     }
        //     else
        //     {
        //         WriteLine($"\nVous avez appuyé sur {key.Key}. Mauvaise touche.");
        //     }

        // }

        // WriteLine($"\nBravo\n");

        // Clear();
        CursorVisible = false;
        string[] labels = {"NOUVELLE PARTIE", "CHARGER", "OPTIONS", "QUITTER CETTE FAKE APPLI DE MORT"};
        var menu = new Menu(labels);
        menu.DisplayMenu();
        menu.MoveCursor();
        ReadLine();


    }
}
