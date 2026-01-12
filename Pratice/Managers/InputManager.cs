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

    public static void GetUserInput()
    {
        _currentKey = ConsoleKey.Clear;

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo inputInfo = Console.ReadKey(true);
            ConsoleKey input = inputInfo.Key;

            foreach (ConsoleKey key in Keys)
            {
                if (key == input)
                {
                    _currentKey = input;
                    break;
                }
            }
        }
    }

    public static void ResetKey()
    {
        _currentKey = ConsoleKey.Clear;
    }
}