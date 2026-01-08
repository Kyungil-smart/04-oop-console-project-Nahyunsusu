using System;
using System.Diagnostics; // Stopwatch 사용을 위해 필요
using System.Threading;

public class GameManager
{
    public static bool IsGameOver { get; set; }
    public const string GameName = "아무튼 RPG";
    private PlayerCharacter _player;

    public void Run()
    {
        Init();
        Console.CursorVisible = false;

        // 60프레임을 위한 설정 (1초 / 60 = 약 16.67ms)
        const double targetFPS = 60.0;
        const double msPerFrame = 1000.0 / targetFPS;

        Stopwatch stopwatch = new Stopwatch();

        while (!IsGameOver)
        {
            stopwatch.Restart(); // 루프 시작 시간 측정

            // 1. 입력
            InputManager.GetUserInput();

            if (InputManager.GetKey(ConsoleKey.L))
            {
                SceneManager.Change("Log");
            }

            // 2. 업데이트
            SceneManager.Update();

            // 3. 렌더링 (깜빡임 방지를 위해 커서 이동 방식 사용)
            Console.SetCursorPosition(0, 0);
            SceneManager.Render();

            // 4. 프레임 제어
            double elapsed = stopwatch.Elapsed.TotalMilliseconds; // 로직 실행에 걸린 시간
            if (elapsed < msPerFrame)
            {
                // 목표 시간(16.6ms)에서 실행 시간을 뺀 만큼만 대기
                Thread.Sleep((int)(msPerFrame - elapsed));
            }
        }
    }

    private void Init()
    {
        IsGameOver = false;
        SceneManager.OnChangeScene += InputManager.ResetKey;
        _player = new PlayerCharacter();

        SceneManager.AddScene("Title", new TitleScene());
        SceneManager.AddScene("Story", new StoryScene());
        SceneManager.AddScene("Town", new TownScene(_player));
        SceneManager.AddScene("Log", new LogScene());

        SceneManager.Change("Title");

        Debug.Log("게임 데이터 초기화 완료");
    }
}