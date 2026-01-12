public class GameOverScene : Scene
{

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Render()
    {
        Console.Clear();
        Console.SetCursorPosition(2, 2);
        Console.Write("████  ███  █   █  ████      ███  █   █  ████  ████\r\n█    █   █ ██ ██  █        █   █ █   █  █     █   █\r\n█ ██ █████ █ █ █  ███      █   █ █   █  ███   ████\r\n█  █ █   █ █   █  █        █   █  █ █   █     █  █\r\n████ █   █ █   █  ████      ███    █    ████  █   █");
    }

    public override void Update()
    {
    }
}
