using System.Text;

public class Map
{
    private Tile[,] _field;
    public int Xsize { get; private set; }
    public int Ysize { get; private set; }

    public Map(int X, int Y)
    {
        Xsize = X;
        Ysize = Y;

        _field = new Tile[Ysize, Xsize];

        for (int y = 0; y < Ysize; y++)
        {
            for (int x = 0; x < Xsize; x++)
            {
                Vector pos = new Vector(x, y);
                _field[y, x] = new Tile(pos);
            }
        }
    }

    public void Init()
    {
        for (int x = 0; x < Xsize; x++)
        {
            _field[0, x].MarkAsBorder();
            _field[Ysize - 1, x].MarkAsBorder();
        }
        for (int y = 1; y < Ysize - 1; y++)
        {
            _field[y, 0].MarkAsBorder();
            _field[y, Xsize - 1].MarkAsBorder();
        }


        DrawHLine(5, 15, 5); 
        DrawVLine(5, 5, 10); 

        DrawVLine(25, 5, 12);
        DrawHLine(20, 30, 15);

        _field[10, 10].MarkAsBorder();
        _field[10, 20].MarkAsBorder();
        _field[5, 30].MarkAsBorder();
        _field[15, 35].MarkAsBorder();

        Random rand = new Random();
        for (int i = 0; i < 15; i++)
        {
            int rx = rand.Next(1, Xsize - 1);
            int ry = rand.Next(1, Ysize - 1);

            if ((rx < 3 && ry < 3) || (rx > 32 && ry > 12)) continue;

            _field[ry, rx].MarkAsBorder();
        }
    }

    private void DrawHLine(int xStart, int xEnd, int y)
    {
        for (int x = xStart; x <= xEnd; x++)
            if (x < Xsize) _field[y, x].MarkAsBorder();
    }

    private void DrawVLine(int x, int yStart, int yEnd)
    {
        for (int y = yStart; y <= yEnd; y++)
            if (y < Ysize) _field[y, x].MarkAsBorder();
    }

    public void Render()
    {
        Console.SetCursorPosition(0, 0);

        StringBuilder sb = new StringBuilder();

        for (int y = 0; y < Ysize; y++)
        {
            for (int x = 0; x < Xsize; x++)
            {
                sb.Append(_field[y, x].GetSymbol());
            }
            sb.AppendLine();
        }

        Console.Write(sb.ToString());
    }

    public bool CheckWall(Vector pos)
    {
        if (pos.X < 0 || pos.X >= Xsize || pos.Y < 0 || pos.Y >= Ysize)
            return true;

        return _field[pos.Y, pos.X].IsWall;
    }
}