public class Wall : GameObject
{
    public Wall(Vector position)
    {
        Symbol = '█'; // 가장자리에 그려질 모양
        Position = position;
    }
}