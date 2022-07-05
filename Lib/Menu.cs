﻿using static System.Console;
using System.Collections.Generic;
namespace ConsoleMenu;
public class Menu
{
    string[] MenuLabels { get; init; }

    string[] Cursor { get; set; }
    int CursorPos { get; set; }
    public Menu(string[] labels)
    {
        MenuLabels = labels;
        CursorPos = 0;
        Cursor = new string[MenuLabels.Length];

    }


    // Affichage du menu
    public void DisplayMenu()
    {
        Clear();
        // Initialisation du curseur et populate des autres préfixes 
        for (int y = 0; y < MenuLabels.Length; y++)
        {
            Cursor[y] = "     ";
        }
        Cursor[CursorPos] = " -->   "; 

        for (int i = 0; i < MenuLabels.Length; i++)
        {

            WriteLine(Cursor[i] + MenuLabels[i]);
        }
    }



    // Changement de l'affichage en fonction de l'input
    public void MoveCursor()
    {
        ConsoleKeyInfo keyPressed;
        bool enter = false;
        while(!enter)
        {
            keyPressed = ReadKey();
            if(keyPressed.Key == ConsoleKey.DownArrow) // Si fleche du bas
            {
                if(CursorPos == MenuLabels.Length-1)
                {
                    CursorPos = 0;
                    DisplayMenu();
                }
                else
                {
                    CursorPos += 1;
                    DisplayMenu();
                }
            }
            else if(keyPressed.Key == ConsoleKey.UpArrow) // Si fleche du haut
            {
                if(CursorPos == 0)
                {
                    CursorPos = MenuLabels.Length-1;
                    DisplayMenu();
                }
                else
                {
                    CursorPos -= 1;
                    DisplayMenu();
                }
            }
            else if(keyPressed.Key == ConsoleKey.Enter || keyPressed.Key == ConsoleKey.Spacebar)
            {
                enter = true;
            }
        }
        Write(Choose(MenuLabels[CursorPos]));
    }

    public string Choose(string label)
    {
        Clear();
        return $"Vous avez choisi {label}";
    }
}


