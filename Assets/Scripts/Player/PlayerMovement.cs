using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public bool Grounded { get; private set; }
    public Vector2 RBVel => _rb.velocity;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [Range(0, 1)]
    [SerializeField] private float _dragDelta;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    
    private float _inputX;
    private Rigidbody2D _rb;
    private BoxCollider2D _collider;
    private bool _canMove => LevelManager.IsRunning;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Grounded = DetectGround();
        _inputX = Input.GetAxisRaw("Horizontal");
        Movement();
        if (Grounded)
        {
            if (Input.GetButtonDown("Jump") && _canMove)
            {
                _rb.velocity *= Vector2.right;
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private bool DetectGround()
    {
        return Physics2D.OverlapBox(transform.position + (Vector3.down * (_collider.size.y * .5f)), new Vector2(_collider.size.x, .3f), 0, _groundLayer);
    }

    private void Movement()
    {
        var moving = Mathf.Abs(_inputX) > .5f;
        
        if (moving && _canMove)
        {
            _rb.AddForce(Vector2.right * (_inputX * _speed * Time.deltaTime), ForceMode2D.Impulse);
        }
        
        var vel = _rb.velocity;
        vel.x = Mathf.Clamp(vel.x, -_maxSpeed, _maxSpeed);
        
        if (!moving && Grounded)
        {
            vel.x = Mathf.Lerp(vel.x, 0, _dragDelta);
        }
        
        _rb.velocity = vel;
    }
}
