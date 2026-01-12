public class GameOverScene : Scene
{
    private string[] gameOverLogo = new string[]
    {
        "████  ███  █   █  ████      ███  █   █  ████  ████",
        "█    █   █ ██ ██  █        █   █ █   █  █     █   █",
        "█ ██ █████ █ █ █  ███      █   █ █   █  ███   ████",
        "█  █ █   █ █   █  █        █   █  █ █   █     █  █",
        "████ █   █ █   █  ████      ███    █    ████  █   █"
    };

    public override void Enter() { }

    public override void Exit() { }

    public override void Render()
    {
        int x = 2; 
        int y = 2; 

        for (int i = 0; i < gameOverLogo.Length; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write(gameOverLogo[i]);
        }
    }

    public override void Update() { }
}