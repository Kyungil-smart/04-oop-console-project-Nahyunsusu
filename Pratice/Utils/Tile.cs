public struct Tile
{
    public GameObject OnTileObject { get; set; }
    public event Action OnStepPlayer;
    public Vector Position { get; set; }

    public bool HasGameObject => OnTileObject != null;

    public bool IsWall = false;

    public Tile(Vector position)
    {
        Position = position;
        OnTileObject = null;
        OnStepPlayer = null;
    }

    public void Print()
    {
        if (HasGameObject)
        {
            OnTileObject.Symbol.Print();
            IsWall = true;
        }
        else
        {
            ' '.Print();
        }
    }

    public void MarkAsBorder()
    {
        OnTileObject = new Wall(Position);
        IsWall = true;
    }

    public char GetSymbol()
    {
        if (OnTileObject != null)
            return OnTileObject.Symbol;

        return ' '; // 빈 타일은 공백
    }
}