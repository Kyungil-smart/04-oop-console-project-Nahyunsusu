using System;
using System.Collections.Generic;
using System.Text;

public class Enemy : GameObject
{
    public Vector  curPos;
    public Vector nextPos;

    private double moveTimer = 0;      
    private double moveInterval = 100   ; 
    public Enemy()
    {
        Init();
    }
    void Init()
    {
        Symbol = 'X';

        Position = new Vector(35, 15);

        curPos = Position;
        nextPos = Position;
    }

    public void Update(Vector playerPos, Map map, double deltaTime)
    {
        moveTimer += deltaTime;

        if (moveTimer >= moveInterval)
        {
            BFS(playerPos, map);
            moveTimer = 0;     
        }
    }

    public void Render()
    {
        Console.SetCursorPosition(curPos.X, curPos.Y);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(Symbol);
        Console.ResetColor();
    }

    public void BFS(Vector playerPos, Map map)
    {
        Queue<Vector> queue = new Queue<Vector>();
        Dictionary<Vector, Vector> parent = new Dictionary<Vector, Vector>();

        Vector start = this.Position;
        queue.Enqueue(start);
        parent[start] = start;

        Vector[] directions = { Vector.Up, Vector.Down, Vector.Left, Vector.Right };
        bool found = false;

        while (queue.Count > 0)
        {
            Vector current = queue.Dequeue();

            if (current.X == playerPos.X && current.Y == playerPos.Y)
            {
                found = true;
                break;
            }

            foreach (Vector dir in directions)
            {
                Vector next = current + dir;

                if (!map.CheckWall(next) && !parent.ContainsKey(next))
                {
                    parent[next] = current; 
                    queue.Enqueue(next);
                }
            }
        }

        if (found)
        {
            Vector pathStep = playerPos;
            while (parent[pathStep].X != start.X || parent[pathStep].Y != start.Y)
            {
                pathStep = parent[pathStep];
            }

            Position = pathStep;
            curPos = Position;
        }
    }
}
