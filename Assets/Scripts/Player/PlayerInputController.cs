using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    // send Message ���
    // ������ ����
    // Move�� �Ͼ �� �����ڵ鿡��(callmoveevent) �˷���
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        // ���콺 position�� �޾ƿ�
        Vector2 newAim = value.Get<Vector2>();
        // ���콺 ��ǥ(UI, screen ��ǥ)�� ���� ��ǥ�� ��ȯ
        // worldPos: ���콺�� ����� ������
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        // ���� ��ǥ���� Player ��ǥ�� ����
        // ���� ��ǥ�� ���ϴ� ���� ���� - ũ��� ��ǥ�� �� ��ŭ
        // �� ũ�⸦ normalized�� ���� ���� ���� - ���� ���ͷ� �������
        newAim = (worldPos - (Vector2)transform.position).normalized;

        // magnitude - 3D���� ���� -> �ӵ� ����
        if (newAim.magnitude >= .9f)
            CallLookEvent(newAim);
    }

    public void OnJump()
    {
        CallJumpEvent();
    }
}
