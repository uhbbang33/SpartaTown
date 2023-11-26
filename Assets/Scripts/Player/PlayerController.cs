using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Action 값을 반환하지 않는 메서드를 나타내는 델리게이트 (Func: 값을 반환)
    // event: 외부에서 호출하지 못하게 막아주는 기능
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnJumpEvent;
    public event Action OnStopMoveEvent;

    public void CallMoveEvent(Vector2 direction)
    {// Action 실행
        // ?: Null이 아닐때만 작동
        // 이벤트에 Action이 잘 걸려있을 때만 작동을 하겠다.       
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallJumpEvent()
    {
        OnJumpEvent?.Invoke();
    }

    public void CallStopMoveEvent()
    {
        OnStopMoveEvent?.Invoke();
    }
}
