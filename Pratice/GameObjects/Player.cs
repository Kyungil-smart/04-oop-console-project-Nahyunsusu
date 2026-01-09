using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

public class Player : GameObject
{
    public ObservableProperty<int> Health = new ObservableProperty<int>(5);
    public bool IsActiveControl { get; private set; }

    public Vector  curPos;
    public Vector nextPos;

    public Player()
    {
        Init();
    }

    public void Init()
    {
        Symbol = 'P';

        IsActiveControl = true;

        curPos = Position;
    }

    public void Update()
    {
        nextPos = Position;

        if (InputManager.GetKey(ConsoleKey.UpArrow)) 
            nextPos += Vector.Up;
        else if (InputManager.GetKey(ConsoleKey.DownArrow)) 
            nextPos += Vector.Down;
        else if (InputManager.GetKey(ConsoleKey.LeftArrow)) 
            nextPos += Vector.Left;
        else if (InputManager.GetKey(ConsoleKey.RightArrow)) 
            nextPos += Vector.Right;

    }

    public void Render()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(Symbol);
        Console.ResetColor();
    }

    public void ConfirmMove()
    {
        Position = nextPos;
    }
}
