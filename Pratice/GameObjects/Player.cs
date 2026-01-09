using System;
using System.Collections.Generic;
using System.Text;

public class Player : GameObject
{
    public ObservableProperty<int> Health = new ObservableProperty<int>(5);
    private string _healthGauge;

    public bool IsActiveControl { get; private set; }

    public Vector  curPos;
    public Vector nextPos;

    public Player()
    {
        Init();
    }

    public void Init()
    {
        Symbol = 'P';

        IsActiveControl = true;

        Health.AddListener(SetHealthGauge);
        _healthGauge = "■■■■■";

        curPos = Position;
    }

    public void Update()
    {
        nextPos = Position;

        if (InputManager.GetKey(ConsoleKey.UpArrow)) nextPos += Vector.Up;
        else if (InputManager.GetKey(ConsoleKey.DownArrow)) nextPos += Vector.Down;
        else if (InputManager.GetKey(ConsoleKey.LeftArrow)) nextPos += Vector.Left;
        else if (InputManager.GetKey(ConsoleKey.RightArrow)) nextPos += Vector.Right;
    }

    public void ConfirmMove()
    {
        Position = nextPos;
    }

    public void SetHealthGauge(int health)
    {
        switch (health)
        {
            case 5:
                _healthGauge = "■■■■■";
                break;
            case 4:
                _healthGauge = "■■■■□";
                break;
            case 3:
                _healthGauge = "■■■□□";
                break;
            case 2:
                _healthGauge = "■■□□□";
                break;
            case 1:
                _healthGauge = "■□□□□";
                break;
        }
    }
}
