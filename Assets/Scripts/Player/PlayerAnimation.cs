using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController _contorller;

    [SerializeField] SpriteRenderer _playerRenderer;
    [SerializeField] Animator _playerAnimator;

    private void Awake()
    {
        _contorller = GetComponentInParent<PlayerController>();
    }

    void Start()
    {
        _contorller.OnMoveEvent += SetWalkAnimation;
        _contorller.OnJumpEvent += SetJumpTrigger;
        _contorller.OnStopMoveEvent += SetIdleAnimation;
    }

    private void SetWalkAnimation(Vector2 direction)
    {
        _playerAnimator.SetBool("IsWalk", true);
    }

    private void SetIdleAnimation()
    {
        _playerAnimator.SetBool("IsWalk", false);
    }

    private void SetJumpTrigger()
    {
        _playerAnimator.SetTrigger("Jump");
    }
}
