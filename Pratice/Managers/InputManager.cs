public static class InputManager
{
    private static ConsoleKey _currentKey = ConsoleKey.Clear;
    private static readonly ConsoleKey[] Keys =
    {
        ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow,
        ConsoleKey.Enter, ConsoleKey.I, ConsoleKey.L, ConsoleKey.T
    };

    public static bool GetKey(ConsoleKey input)
    {
        return _currentKey == input;
    }

    // GameManager의 Update 루프에서 매번 호출
    public static void GetUserInput()
    {
        // 1. 이전 프레임의 입력 초기화
        _currentKey = ConsoleKey.Clear;

        // 2. 키 입력이 있는 경우에만 처리 (비블로킹)
        if (Console.KeyAvailable)
        {
            // 실제 키를 읽어옴
            ConsoleKeyInfo inputInfo = Console.ReadKey(true);
            ConsoleKey input = inputInfo.Key;

            // 3. 허용된 키 목록에 있는지 확인
            foreach (ConsoleKey key in Keys)
            {
                if (key == input)
                {
                    _currentKey = input;
                    break;
                }
            }
        }
        // else일 때는 아무것도 하지 않음 -> _currentKey는 Clear 상태로 유지되어 루프가 계속 돔
    }

    public static void ResetKey()
    {
        _currentKey = ConsoleKey.Clear;
    }
}