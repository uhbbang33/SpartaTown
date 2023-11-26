using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController _contorller;

    [SerializeField] SpriteRenderer _playerRenderer;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _contorller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _contorller.OnMoveEvent += Move;
        _contorller.OnLookEvent += Look;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Update()
    {
        if (_movementDirection == Vector2.zero)
            _contorller.CallStopMoveEvent();
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void Look(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _playerRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void ApplyMovement(Vector2 direction)
    {
        _rigidbody.velocity = direction * 5;
    }
}
