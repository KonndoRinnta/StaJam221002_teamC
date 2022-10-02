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
    [Tooltip("�W�����v�̓��͔���")] bool _inputJump;
    [Tooltip("�ڒn����")] bool _isGround;

    Rigidbody2D _rb;
    Animator _animator;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        {
            _inputJump = true;
            _jumpCount++;
        }
        else
        {
            _inputJump = false;
        }

        _animator.SetFloat("MoveX", _rb.velocity.x);
        _animator.SetFloat("MoveY", _rb.velocity.y);
    }


    void FixedUpdate()
    {
        MoveHorizontal();
        Jump();
    }


    /// <summary>�������̈ړ����s�����\�b�h</summary>
    void MoveHorizontal()
    {
        _rb.velocity = new Vector2(_inputX * _moveSpeed, _rb.velocity.y);
    }


    /// <summary>�W�����v�̏������s�����\�b�h</summary>
    void Jump()
    {
        if (_jumpCount < _jumpLimit)
        {
            _rb.AddForce(transform.up * _jumpPower);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //�ڒn����
        if (collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
        }
    }
}
