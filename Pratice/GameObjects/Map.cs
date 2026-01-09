public class Map
{
    private Tile[,] _field;
    int Xsize;
    int Ysize;

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
    }

    public void Render()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < Ysize; y++)
        {
            for (int x = 0; x < Xsize; x++)
            {
                _field[y, x].Print();
            }
            Console.WriteLine();
        }
    }

    public bool CheckWall(Vector pos)
    {
        if (pos.X < 0 || pos.X >= Xsize || pos.Y < 0 || pos.Y >= Ysize)
            return true;

        return _field[pos.Y, pos.X].IsWall;
    }
}