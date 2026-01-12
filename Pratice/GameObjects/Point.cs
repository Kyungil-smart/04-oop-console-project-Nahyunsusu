using System;
using System.Collections.Generic;
using System.Text;

public class Point : GameObject
{
    Random rand;

    int Xsize;
    int Ysize;

    Map map;

    public void Init(ref Map map)
    {
        Symbol = 'O';

        rand = new Random();

        Xsize = map.Xsize;
        Ysize = map.Ysize;

        this.map = map;
        UpdatePos();
    }

    public void Update(Player player)
    {
        CheckPlayer(player);
    }

    public void Render()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(Symbol);
        Console.ResetColor();
    }

    void UpdatePos()
    {
        while(true)
        {
            rand.Next(Xsize);
            int temp = rand.Next(Xsize);
            Vector nextPos = new Vector(temp, rand.Next(Ysize));
            Position = nextPos;
            if (map.CheckWall(Position) == false)
                break;
        }
    }

    public void CheckPlayer(Player player)
    {
        if (Position == player.Position)
        {
            UpdatePos();
        }

    }
}