using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

public class Score
{
    public int score = 0;

    public void PlusScore()
    {
        score++;
    }

    public void Render(ref Map map)
    {
        Console.SetCursorPosition(map.Xsize + 2, 0);
        Console.Write($"Point = {score}");
    }
}
