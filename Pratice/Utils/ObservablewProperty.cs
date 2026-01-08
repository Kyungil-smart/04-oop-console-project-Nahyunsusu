using System;
using System.Collections.Generic;

public class ObservableProperty<T> where T : struct
{
    private T _value;

    public T Value
    {
        get => _value;
        set
        {
            // 1. 값이 이전과 같으면 업데이트하지 않음 (최적화)
            if (EqualityComparer<T>.Default.Equals(_value, value))
                return;

            _value = value;

            // 2. 이벤트를 안전하게 호출
            OnValueChange?.Invoke(_value);
        }
    }

    // 델리게이트 체인을 외부에서 직접 수정하지 못하도록 이벤트 키워드 유지
    public event Action<T> OnValueChange;

    public ObservableProperty(T value = default)
    {
        _value = value;
    }

    // 편의를 위한 연산자 오버로딩 (선택 사항)
    public static implicit operator T(ObservableProperty<T> observable) => observable.Value;

    public void Add(Action<T> action)
    {
        if (action != null) OnValueChange += action;
    }

    public void Remove(Action<T> action)
    {
        if (action != null) OnValueChange -= action;
    }

    public void RemoveAll()
    {
        // 이벤트 핸들러 초기화
        OnValueChange = null;
    }
}