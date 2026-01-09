using System;
using System.Collections.Generic;
using System.Text;
internal class TestScene : Scene
{
    int Xsize = 20;
    int Ysize = 20;
    Map map = new Map(20, 20);
    Player player = new Player();

    public override void Enter()
    {
        map.Init();

        player.Position = new Vector(1, 1);
        player.nextPos = player.Position;

        Console.WriteLine("TestScene Enter");
    }

    public override void Update()
    {
        player.Update();

        if (player.Position != player.nextPos)
        {
            if (map.CheckWall(player.nextPos) == false)
            {
                player.ConfirmMove();
            }
        }
    }

    public override void Render()
    {
        map.Render();

        Console.SetCursorPosition(player.Position.X, player.Position.Y);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(player.Symbol);
        Console.ResetColor();
    }


    public override void Exit()
    {
    }

    public bool CheckWall(Vector pos)
    {
        if (pos.X < 0 || pos.X >= Xsize || pos.Y < 0 || pos.Y >= Ysize)
            return true;

        return false;
    }
}
