using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
public class TestScene : Scene
{
    int Xsize = 40;
    int Ysize = 20;
    Map map;
    Player player = new Player();
    Enemy Enemy;

    public override void Enter()
    {
        map = new Map(Xsize, Ysize);
        map.Init();

        player.Position = new Vector(1, 1);
        player.nextPos = player.Position;

        Enemy = new Enemy();

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
            else
            {
                player.nextPos = player.Position;
            }
        }

        double deltaTime = 1000.0 / 60.0;
        Enemy.Update(player.Position, map, deltaTime);

        if(player.nextPos == Enemy.curPos)
        {
            player.IsActiveControl = false;
        }
    }

    public override void Render()
    {
        map.Render();

        player.Render();

        Enemy.Render();
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