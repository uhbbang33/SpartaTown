using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Action ���� ��ȯ���� �ʴ� �޼��带 ��Ÿ���� ��������Ʈ (Func: ���� ��ȯ)
    // event: �ܺο��� ȣ������ ���ϰ� �����ִ� ���
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnJumpEvent;
    public event Action OnStopMoveEvent;

    public void CallMoveEvent(Vector2 direction)
    {// Action ����
        // ?: Null�� �ƴҶ��� �۵�
        // �̺�Ʈ�� Action�� �� �ɷ����� ���� �۵��� �ϰڴ�.       
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
