using static System.Console;
using System.Collections.Generic;
namespace ConsoleMenu;
public class Room
{
    int Height { get; init; }
    int Width { get; init; }
    int OriginalX { get; init; }
    int OriginalY { get; init; }
    int ObstaclesNb { get; init; }
    int[] PlayerPos = { 1, 1 };
    string[,] RoomArray { get; set; }
    bool IsAlive = true;

    public Room(int oX, int oY)
    {
        var rand = new Random();
        Height = 30;
        Width = 30;
        ObstaclesNb = (Height + Width) / 4;
        OriginalX = oX;
        OriginalY = oY;
        RoomArray = new string[Width+1, Height+1];
    }

/// <summary>
/// Used to write a string to a specific console location
/// </summary>
/// <param name="s">String you want to draw</param>
/// <param name="x"> X axis of console + the original location of the room </param>
/// <param name="y"> Y axis of console + the original location of the room </param>
    protected void WriteAt(string s, int x, int y)
        {
        try
            {
                SetCursorPosition(this.OriginalX+x, this.OriginalY+y);
                Write(s);
            }
        catch (ArgumentOutOfRangeException e)
            {
                Clear();
                WriteLine(e.Message);
            }
        }


/// <summary>
/// Fills the 2d room array and draw it on console
/// </summary>
    public void DrawRoom()
    {

        // Populate array
        for (int x = 0; x <= Width; x++)
        {
            for (int y = 0; y <= Height; y++)
            {
                // Spawn
                if(x == PlayerPos[0] && y == PlayerPos[1])
                {
                    RoomArray[PlayerPos[0], PlayerPos[1]] = "@";
                    WriteAt
                    (
                        RoomArray[PlayerPos[0], PlayerPos[1]], 
                        PlayerPos[0], 
                        PlayerPos[1]
                    );
                }

                else if(x == 0 && y == 0 || x == Width && y == 0 || x == 0 && y == Height || x == Width && y == Height)
                {
                    RoomArray[x, y] = "+";
                    WriteAt(RoomArray[x, y], x, y);
                }
                else if (x == 0 && y != 0 || x == Width && y != Height || x != 0 && y == Height || x != 0 && y == 0 )
                {
                    RoomArray[x, y] = "#";
                    WriteAt(RoomArray[x, y], x, y);
                }
                else
                {
                    RoomArray[x, y] = "--";
                    WriteAt(RoomArray[x, y], x, y);
                }
            }
        }

        // Obstacles
        var rand = new Random();
        int obstaclesCount = 0;
        while(obstaclesCount < ObstaclesNb)
        {
            for (int x = 2; x <= (Width - 2); x++)
            {
                if(obstaclesCount == ObstaclesNb)
                {
                    break;
                }
                for (int y = 2; y <= (Height - 2); y++)
                {
                    if(obstaclesCount == ObstaclesNb)
                    {
                        break;
                    }
                    if(rand.Next(101) == 1)
                    {
                        RoomArray[x, y] = "X";
                        WriteAt(RoomArray[x, y], x, y);
                        obstaclesCount += 1;
                    }
                }
            }
        }
        // Fin obstacles
    }


/// <summary>
/// Check if there's an obstacle on player's destination
/// </summary>
/// <param name="destinationX"> X axis aimed by player </param>
/// <param name="destinationY"> Y axis aimed by player </param>
/// <returns></returns>
    protected bool CheckMove(int destinationX, int destinationY)
    {
        bool checkMove;
        if (RoomArray[destinationX, destinationY] == "X" || RoomArray[destinationX, destinationY] == "#")
        {
            checkMove = false;
        }
        else
        {
            checkMove = true;
        }
        return checkMove;
    }
/// <summary>
/// Moving the player Up, Right, Down or Left.
/// </summary>
    protected void Move()
    {
        ConsoleKeyInfo keyPressed;
        keyPressed = ReadKey();

        if (keyPressed.Key == ConsoleKey.DownArrow)
        {
            if(CheckMove((PlayerPos[0]), PlayerPos[1]+1))
            {
                PlayerPos[1] += 1;
                RoomArray[PlayerPos[0], PlayerPos[1]] = "@";
                RoomArray[PlayerPos[0], PlayerPos[1]-1] = "--";
            }
            WriteAround(); 
            
        } 
        else if (keyPressed.Key == ConsoleKey.UpArrow)
        {
            if(CheckMove((PlayerPos[0]), PlayerPos[1]-1))
            {
                PlayerPos[1] -= 1;
                RoomArray[PlayerPos[0], PlayerPos[1]] = "@";
                RoomArray[PlayerPos[0], PlayerPos[1]+1] = "--";
            }
            WriteAround(); 
        } 
        
        else if (keyPressed.Key == ConsoleKey.RightArrow)
        {
            if(CheckMove((PlayerPos[0]+1), PlayerPos[1]))
            {
                PlayerPos[0] += 1;
                RoomArray[PlayerPos[0], PlayerPos[1]] = "@";
                RoomArray[PlayerPos[0]-1, PlayerPos[1]] = "--";
            }
            WriteAround();   
        } 
        else if (keyPressed.Key == ConsoleKey.LeftArrow)
        {
            if(CheckMove((PlayerPos[0]-1), PlayerPos[1]))
            {
                PlayerPos[0] -= 1;
                RoomArray[PlayerPos[0], PlayerPos[1]] = "@";
                RoomArray[PlayerPos[0]+1, PlayerPos[1]] = "--";
            }
            WriteAround();   
        }
        else
        {
            WriteAt(RoomArray[PlayerPos[0], PlayerPos[1]], PlayerPos[0], PlayerPos[1]);
        } 
        
    }
    // Play 
    public void Play()
    {
        while(IsAlive)
        {
            Move();
        }
    }



    protected void WriteAround()
    {
        for (int x = 0; x <= Width; x++)
        {
            for (int y = (PlayerPos[1] - 1); y <= (PlayerPos[1] + 1); y++)
            {
                WriteAt(RoomArray[x, y], x, y);
            }
        }
    }
}
