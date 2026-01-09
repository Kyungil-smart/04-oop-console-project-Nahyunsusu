using System;
using System.Diagnostics; // Stopwatch 사용을 위해 필요
using System.Threading;

public class GameManager
{
    public static bool IsGameOver { get; set; }
    public const string GameName = "아무튼 RPG";

    public void Run()
    {
        Init();
        Console.CursorVisible = false;

        const double targetFPS = 60.0;
        const double msPerFrame = 1000.0 / targetFPS;

        Stopwatch stopwatch = new Stopwatch();

        while (!IsGameOver)
        {
            stopwatch.Restart();

            InputManager.GetUserInput();

            SceneManager.Update();

            Console.SetCursorPosition(0, 0);
            SceneManager.Render();

            double elapsed = stopwatch.Elapsed.TotalMilliseconds; 
            if (elapsed < msPerFrame)
            {
                Thread.Sleep((int)(msPerFrame - elapsed));
            }
        }
    }

    private void Init()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        IsGameOver = false;
        SceneManager.OnChangeScene += InputManager.ResetKey;

        SceneManager.AddScene("Test", new TestScene());

        SceneManager.Change("Test");

        Debug.Log("게임 데이터 초기화 완료");
    }
}