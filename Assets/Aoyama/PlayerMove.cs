using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("�ړ��̃X�s�[�h")] float _moveSpeed = 20;
    [SerializeField, Tooltip("�W�����v�̗�")] float _jumpPower = 10f;
    [SerializeField, Tooltip("�W�����v�\�ȉ�")] int _jumpLimit = 1;

    [Tooltip("�W�����v�̉�")] int _jumpCount;
    [Tooltip("x���̓��͔���")] float _inputX;
    [Tooltip("Flip�̂��߂ɒl��ۑ����Ă����p�̕ϐ�")] float _x = 1;
    [Tooltip("�W�����v�̓��͔���")] bool _isJump;

    [SerializeField] AudioSource _audio;

    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;
    Animator _animator;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");

        Jump();
    }


    void FixedUpdate()
    {
        MoveHorizontal();
        PlayerFlip();

        //Animator�̏���
        _animator.SetFloat("MoveX", _rb.velocity.x);
        _animator.SetBool("IsJump", _isJump);
    }


    /// <summary>�v���C���[����]�����郁�\�b�h</summary>
    void PlayerFlip()
    {
        if (_inputX != 0)
        {
            _x = _inputX;
        }

        if (_x > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }


    /// <summary>�������̈ړ����s�����\�b�h</summary>
    void MoveHorizontal()
    {
        _rb.velocity = new Vector2(_inputX * _moveSpeed, _rb.velocity.y);
    }


    /// <summary>�W�����v�̏������s�����\�b�h</summary>
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_jumpCount < _jumpLimit && !_isJump)
            {
                _audio.Play();
                _rb.velocity = Vector2.zero;
                _rb.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
                _isJump = true;
                _jumpCount++;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //�ڒn����
        if (collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
            _isJump = false;
        }
    }
}
