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

    // send Message 방식
    // 옵저버 패턴
    // Move가 일어날 때 구독자들에게(callmoveevent) 알려줌
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        // 마우스 position을 받아옴
        Vector2 newAim = value.Get<Vector2>();
        // 마우스 좌표(UI, screen 좌표)를 월드 좌표로 변환
        // worldPos: 마우스의 월드상 포지션
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        // 월드 좌표에서 Player 좌표를 빼면
        // 월드 좌표로 향하는 값이 나옴 - 크기는 좌표를 뺀 만큼
        // 그 크기를 normalized를 통해 단위 벡터 - 방향 벡터로 만들어줌
        newAim = (worldPos - (Vector2)transform.position).normalized;

        // magnitude - 3D에서 문제 -> 속도 관련
        if (newAim.magnitude >= .9f)
            CallLookEvent(newAim);
    }

    public void OnJump()
    {
        CallJumpEvent();
    }
}
