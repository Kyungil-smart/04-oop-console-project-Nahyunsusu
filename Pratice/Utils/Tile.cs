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
    }
}