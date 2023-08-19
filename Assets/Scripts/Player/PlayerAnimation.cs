using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private PlayerMovement _playerMove;
    private SpriteRenderer _spriteRender;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _spriteRender = GetComponent<SpriteRenderer>();
        _playerMove = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        _anim.SetBool("Grounded", _playerMove.Grounded);
        _anim.SetFloat("XSpeedABS", Mathf.Abs(_playerMove.RBVel.x));
        _anim.SetFloat("YSpeed", _playerMove.RBVel.y);
        _spriteRender.flipX = Mathf.Sign(_playerMove.RBVel.x) < 0;
    }
}
