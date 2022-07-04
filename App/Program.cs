using static System.Console;

namespace App;
class Program
{
    static void Main(string[] args)
    {
        

        
        
        ConsoleKeyInfo key;
        bool ok = false;
        while(!ok)
        {
            Write("Appuyez sur entrée pour clear la console : ");
            key = ReadKey();
            ok = key.Key switch
            {
                ConsoleKey.Enter => true,
                _ => false
                
            };
            if(key.Key == ConsoleKey.Enter)
            {
                ok = true;
            }
            else
            {
                WriteLine($"\nVous avez appuyé sur {key.Key}. Mauvaise touche.");
            }

        }

        WriteLine($"\nBravo\n");
        
        Clear();


    }
}
